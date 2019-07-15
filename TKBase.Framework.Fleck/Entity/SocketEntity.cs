using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.Fleck.Entity
{
    /// <summary>
    ///  Socket的请求实体
    /// </summary>
    public class SocketEntity
    {
        /// <summary>
        /// 操作
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        ///Socket编号
        /// </summary>
        public string SocketName { get; set; }

    }
    /// <summary>
    /// Socket连接对象
    /// </summary>
    public class SocketConnection
    {
        /// <summary>
        /// 对象名称
        /// </summary>
        public string SocketName { get; set; }

        /// <summary>
        /// 对象
        /// </summary>
        public IWebSocketConnection WebSocket { get; set; }
    }
}
