﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.MQTT
{
    /// <summary>
    /// 
    /// </summary>
    public class WebSocketConfig
    {
        /// <summary>
        /// 请求路径
        /// </summary>
        public static string Uri { get; set; }

        /// <summary>
        /// 心跳数
        /// </summary>
        public static double KeepAlivePeriod { get; set; }

        /// <summary>
        /// 会话时长
        /// </summary>
        public static double KeepAliveSendInterval { get; set; }
    }
}
