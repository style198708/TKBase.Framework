/******************************************************
* author :  Lenny
* email  :  niel@dxy.cn 
* function: 
* time:	2017/8/3 10:30:44 
* clrversion :	4.0.30319.42000
******************************************************/

using System;
using System.Collections.Generic;
using System.Configuration;

namespace TKBase.Framework.MRPC.Config
{
    public class MConfig
    {
        /// <summary>
        /// 服务器
        /// </summary>
        public static string Host { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public static int Port { get; set; }

        /// <summary>
        /// 服务实现集
        /// </summary>
        public  static List<string> Services { get; set; }

    }
}
