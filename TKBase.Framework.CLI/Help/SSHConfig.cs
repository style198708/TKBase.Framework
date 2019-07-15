using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.CLI
{
    public class SSHConfig
    {
        /// <summary>
        /// 主机
        /// </summary>
        public static string Host { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public static string User { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public static string PassWord { get; set; }
    }
}
