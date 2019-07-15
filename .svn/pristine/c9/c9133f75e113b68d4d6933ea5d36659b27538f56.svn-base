using System;
using System.Collections.Generic;
using System.Text;
using TKBase.Framework.Thrift.Config;
using TKBase.Framework.Thrift.EventHandler;
using TKBase.Framework.Thrift.Protocol;
using TKBase.Framework.Thrift.Server;
using TKBase.Framework.Thrift.Transport;

namespace TKBase.Framework.Thrift
{
    public class THelp
    {
        /// <summary>
        /// 创建服务端
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public static void Server<T>(T entity, string config) where T : TProcessor
        {
            ServerConfig server = TConfigurationRoot.Bind<ServerConfig>(config);
            Server<T>(entity, server.Port);
        }

        /// <summary>
        /// 创建服务端
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public static void Server<T>(T entity, int serverPort) where T : TProcessor
        {
            try
            {
                TServerSocket serverTransport = new TServerSocket(serverPort);
                TBinaryProtocol.Factory factory = new TBinaryProtocol.Factory();
                //TMultiplexedProcessor processorMulti = new TMultiplexedProcessor();
                //processorMulti.RegisterProcessor("Service", entity);

                TServer server = new TThreadPoolServer(entity, serverTransport, new TTransportFactory(), factory);
               
                Console.WriteLine(string.Format("服务端正在监听{0}端口", serverPort));
                server.Serve();
            }
            catch (TTransportException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 创建客户端
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serverIp"></param>
        /// <param name="serverPort"></param>
        /// <returns></returns>
        public static F Client<F>(string config)
        {
            ServerConfig server = TConfigurationRoot.Bind<ServerConfig>(config);
            return Client<F>(server.ServerIP, server.Port);
        }

        /// <summary>
        /// 创建客户端
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serverIp"></param>
        /// <param name="serverPort"></param>
        /// <returns></returns>
        public static F Client<F>(string serverIp, int serverPort)
        {
            TTransport transport = new TSocket(serverIp, serverPort);
            transport.Open();
            TProtocol protocol = new TBinaryProtocol(transport);
            F entity = (F)Activator.CreateInstance(typeof(F), new object[] { protocol });
            return entity;
        }
    }
}
