using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TKBase.DotNetty.Buffers;
using TKBase.DotNetty.Codecs;
using TKBase.DotNetty.Handlers.Logging;
using TKBase.DotNetty.Handlers.Timeout;
using TKBase.DotNetty.Transport.Bootstrapping;
using TKBase.DotNetty.Transport.Channels;
using TKBase.DotNetty.Transport.Channels.Sockets;
using TKBase.Framework.MRPC.Config;
using TKBase.Framework.MRPC.Enum;
using TKBase.Framework.MRPC.Exceptions;
using TKBase.Framework.MRPC.Proxy;
using TKBase.Framework.MRPC.Transport;

namespace TKBase.Framework.MRPC.Netty
{
    public class DotNettyClient : ITransportClient,IDisposable
    {
        public  IChannel Channel { set; get; }

        public  IEventLoopGroup Group { set; get; }

        public  IPEndPoint EndPoint { get; set; }

        public ClientMessageHandler ClientMessageHandler = new ClientMessageHandler();

        private void Connect(IPEndPoint endPoint)
        {
            Group = new MultithreadEventLoopGroup();
            var bootstrap = new Bootstrap();
            bootstrap
                .Group(Group)
                .Channel<TcpSocketChannel>()
                .Option(ChannelOption.TcpNodelay, true)
                .Handler(new ActionChannelInitializer<ISocketChannel>(channel =>
                {
                    IChannelPipeline pipeline = channel.Pipeline;

                    // IdleStateHandler 客户端定时发送请求到服务器端，心跳检测
                    pipeline.AddLast(new IdleStateHandler(5, 5, 5));

                    pipeline.AddLast(new LengthFieldPrepender(4));
                    pipeline.AddLast(new LengthFieldBasedFrameDecoder(ushort.MaxValue, 0, 4, 0, 4));
                    pipeline.AddLast(ClientMessageHandler);
                }));
            EndPoint = endPoint;
            Channel = bootstrap.ConnectAsync(endPoint).Result;
            
        }
        private void Connect(string host, int port)
        {
            EndPoint = new IPEndPoint(IPAddress.Parse(host), port);
            Connect(EndPoint);
        }


        /// <summary>
        /// 关闭
        /// </summary>
        public async void Close()
        {
            await Channel.CloseAsync();
            await Group.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1));
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        public TransportMessage SendMessage(string message)
        {
            if (message == null)
            {
                return null;
            }
            Connect(MConfig.Host, MConfig.Port);
            bool active = Channel.Active;
            if (!active)
            {
                //ReConnect();
                throw new NotConnectionException("无法连接到服务"); 
            }
            IByteBuffer buffer = Unpooled.Buffer(256);
            TransportMessage transportMessage = new TransportMessage
            {
                Id = Guid.NewGuid().ToString("N"),
                Message = message,
                TransoprtType = TransoprtType.Request
            };

            //注册结果回调
            var callbackTask = ClientMessageHandler.RegisterResultCallbackAsync(transportMessage.Id);
            message = Newtonsoft.Json.JsonConvert.SerializeObject(transportMessage);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            buffer.WriteBytes(messageBytes);
            Channel.WriteAndFlushAsync(buffer);

            TransportMessage transport = callbackTask.Result;
            ClientMessageHandler.ClearResultCallback(transport.Id);
            Close();
            return transport;
        }

        public void Dispose()
        {
             Channel.CloseAsync();
             Group.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1));
        }
    }
}
