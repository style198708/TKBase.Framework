using System;
using System.Collections.Generic;
using System.Text;
using TKBase.Framework.Fleck.Entity;

namespace TKBase.Framework.Fleck
{
    public class FleckService
    {
        /// <summary>
        /// 监听服务
        /// </summary>
        public WebSocketServer Service { get; set; }

        public FleckService(string config)
        {
            Service = new WebSocketServer(config);
            OnOpen = () => { Console.WriteLine("Open!"); };
            OnClose = () => { Console.WriteLine("Close!"); };
            OnMessage = message => { Console.WriteLine(message); };
        }

        /// <summary>
        /// 连接事件
        /// </summary>
        public Action OnOpen { get; set; }

        /// <summary>
        /// 关闭事件
        /// </summary>
        public Action OnClose { get; set; }

        /// <summary>
        /// 收到信息事件
        /// </summary>
        public Action<string> OnMessage { get; set; }


        /// <summary>
        /// 开始
        /// </summary>
        public void Start(Action<IWebSocketConnection> socket)
        {
            Service.Start(socket);
        }
    }
}
