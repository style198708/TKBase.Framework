using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TKBase.DotNetty.Codecs;
using TKBase.DotNetty.Handlers.Logging;
using TKBase.DotNetty.Transport.Bootstrapping;
using TKBase.DotNetty.Transport.Channels;
using TKBase.DotNetty.Transport.Channels.Sockets;
using TKBase.Framework.MRPC.Contracts;
using TKBase.Framework.MRPC.Netty;
using TKBase.Framework.MRPC.Proxy;

namespace TKBase.Framework.MRPC.Server
{
    class Program
    {
      
        static void Start()
        {
            //TKBase.Framework.Configuration.Config.Bind<Config.Config>("rpc.json");
            //MServer hub = new MServer();
            //hub.Start(Config.Config.Port);


             NettyContainer.Client.Connect("127.0.0.1",6969);
            IChatService chatService = InterfaceProxy.Resolve<IChatService>();
            string result = chatService.Hi("李四", "世界和平");

            //Console.WriteLine("服务已经启动 端口：" + port);
        }

        static void Main(string[] args)
        {
            Start();
            Console.ReadKey(); 
        }     
    }
}
