using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TKBase.Framework.MRPC.Netty;
using TKBase.Framework.MRPC.Proxy;

namespace TKBase.Framework.MRPC
{
    public static class MClient
    {
        ///// <summary>
        ///// 初始化长连接
        ///// </summary>
        ///// <param name="config"></param>
        //public static void Connect(string config)
        //{
        //    MConfiguration.Bind<Config.MConfig>(config);
        //    Connect(Config.MConfig.Host, Config.MConfig.Port);
        //}
        ///// <summary>
        ///// 初始化长连接
        ///// </summary>
        ///// <param name="Host"></param>
        ///// <param name="Port"></param>
        //public static void Connect(string Host, int Port)
        //{
        //    NettyContainer.Client.Connect(Host, Port);
            
        //}

        /// <summary>
        /// 初始化客户端
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Host"></param>
        /// <param name="Port"></param>
        /// <returns></returns>
        public static T Client<T>(string config) where T : class
        {
            MConfiguration.Bind<Config.MConfig>(config);
            T client = InterfaceProxy.Resolve<T>();
            return client;
        }
    }
}
