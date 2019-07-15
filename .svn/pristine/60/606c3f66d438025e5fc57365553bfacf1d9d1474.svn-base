using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBase.DotNetty.Buffers;
using TKBase.DotNetty.Transport.Channels;
using TKBase.Framework.MRPC.Enum;
using TKBase.Framework.MRPC.Proxy;

namespace TKBase.Framework.MRPC.Netty
{
    public class ServerMessageHandler : ChannelHandlerAdapter
    {
        public event RequestHandler Handle;

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            if (message is IByteBuffer buffer)
            {
                string receiveData = buffer.ToString(Encoding.UTF8);
                TransportMessage transportMessage =
                    Newtonsoft.Json.JsonConvert.DeserializeObject<TransportMessage>(receiveData);
                if (transportMessage.TransoprtType == TransoprtType.Init)
                {
                    string responseData = "ok";
                    transportMessage.TransoprtType = TransoprtType.Ans;
                    transportMessage.Message = responseData;
                }
                if (transportMessage.TransoprtType == TransoprtType.Request)
                {
                    string responseData = Handle?.Invoke(transportMessage.Message);
                    transportMessage.TransoprtType = TransoprtType.Response;
                    transportMessage.Message = responseData;
                }
                else
                {
                    string responseData = "不需要处理的";
                    transportMessage.TransoprtType = TransoprtType.Response;
                    transportMessage.Message = responseData;
                }

                string responseMessage = Newtonsoft.Json.JsonConvert.SerializeObject(transportMessage);
                byte[] messageBytes = Encoding.UTF8.GetBytes(responseMessage);
                IByteBuffer byteBuffer = Unpooled.Buffer(messageBytes.Length);
                byteBuffer.WriteBytes(messageBytes);
                context.WriteAndFlushAsync(byteBuffer);
            }
        }

        public override void ChannelReadComplete(IChannelHandlerContext context) => context.Flush();

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            context.CloseAsync();
        }
    }
}
