using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.CLI.Supervisor
{
    /// <summary>
    /// 守护进程
    /// </summary>
    public class SupervisorEntity
    {
        /// <summary>
        /// 进程名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 运行程序的命令
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// 命令执行的目录
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// 程序意外退出是否自动重启
        /// </summary>
        public bool AutoreStart { get; set; }

        /// <summary>
        /// 错误日志文件
        /// </summary>
        public string ErrLogFile { get; set; }

        /// <summary>
        /// 输出日志文件
        /// </summary>
        public string OutLogFile { get; set; }

        /// <summary>
        /// 进程环境变量
        /// </summary>
        public string Environment { get; set; }

        /// <summary>
        /// 进程执行的用户身份
        /// </summary>
        public string User { get; set; }
    }
}
