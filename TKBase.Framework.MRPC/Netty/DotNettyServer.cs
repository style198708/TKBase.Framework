﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBase.DotNetty.Codecs;
using TKBase.DotNetty.Handlers.Logging;
using TKBase.DotNetty.Transport.Bootstrapping;
using TKBase.DotNetty.Transport.Channels;
using TKBase.DotNetty.Transport.Channels.Sockets;
using TKBase.Framework.MRPC.Transport;

namespace TKBase.Framework.MRPC.Netty
{
    public class DotNettyServer : ITransportServer
    {
        public static IChannel BoundChannel { set; get; }

        public static MultithreadEventLoopGroup BossGroup { set; get; }

        public static MultithreadEventLoopGroup WorkerGroup { set; get; }

        public async Task Listen(int port)
        {
            BossGroup = new MultithreadEventLoopGroup(1);
            WorkerGroup = new MultithreadEventLoopGroup();
            var bootstrap = new ServerBootstrap();
            bootstrap
                .Group(BossGroup, WorkerGroup)
                .Channel<TcpServerSocketChannel>()
                .Option(ChannelOption.SoBacklog, 100)
                .ChildHandler(new ActionChannelInitializer<ISocketChannel>(channel =>
                {
                    IChannelPipeline pipeline = channel.Pipeline;
                    pipeline.AddLast(new LengthFieldPrepender(4));
                    pipeline.AddLast(new LengthFieldBasedFrameDecoder(int.MaxValue, 0, 4, 0, 4));

                    ServerMessageHandler handler = new ServerMessageHandler();
                    handler.Handle += new RpcDefaultRequestHandler().Handle;
                    pipeline.AddLast(handler);
                }));

            BoundChannel = await bootstrap.BindAsync(port);
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public async void Close()
        {
            await BoundChannel.CloseAsync();
            await BossGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1));
            await WorkerGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1));
        }
    }
}
