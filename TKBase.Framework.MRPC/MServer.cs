/******************************************************
* author :  Lenny
* email  :  niel@dxy.cn 
* function: 
* time:	2017/8/3 10:24:47 
* clrversion :	4.0.30319.42000
******************************************************/

using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using TKBase.Framework.MRPC.Exceptions;
using TKBase.Framework.MRPC.Models;
using TKBase.Framework.MRPC.Netty;
using TKBase.Framework.MRPC.Socket;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace TKBase.Framework.MRPC
{
    public class MServer
    {
        /// <summary>
        ///server 启动端口连接
        /// </summary>
        /// <param name="port"></param>
        public static async void Start(string config)
        {
            MConfiguration.Bind<Config.MConfig>(config);
            RpcConatiner.Initialize();
            DotNettyServer server = new DotNettyServer(); 
            await server.Listen(Config.MConfig.Port);
            System.Console.WriteLine("开始监听{0}:{1}", Config.MConfig.Host, Config.MConfig.Port);
        }


        /// <summary>
        /// 创建TCP连接
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public TcpClient Connect(string host, int port)
        {
            try
            {
                TcpClient client = new TcpClient(host, port);
                return client;
            }
            catch (System.Exception e)
            {
                throw new NotConnectionException("rpc服务出现异常，请查看服务器状态！");
            }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void CloseConnection()
        {
            RpcRequest request = RpcRequest.BuildCloseRequest();
            SyncTcpClient.SendMessage(ClientContainer.Client, JsonConvert.SerializeObject(request), true); //关闭服务端链接
            ClientContainer.Client.Close();
        }
    }
}
