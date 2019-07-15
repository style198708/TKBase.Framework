using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TKBase.Framework.CLI
{
    public class CliProcess : IDisposable
    {
        /// <summary>
        /// 创建dotnet进程
        /// </summary>
        /// <returns></returns>
        public void ExecDotNetProcess(params string[] arg)
        {
            ExecProcess("dotnet", arg);
        }

        /// <summary>
        /// 创建守护进程
        /// </summary>
        /// <param name="arg"></param>
        public void ExecSupervisorProcess(params string[] arg)
        {
            ExecRemoteProcess("supervisorctl", arg);
        }

        /// <summary>
        /// 创建Docker进程
        /// </summary>
        /// <param name="arg"></param>
        public void ExecDockerProcess(params string[] arg)
        {
            ExecRemoteProcess("docker", arg);
        }

        /// <summary>
        /// 执行目录切换
        /// </summary>
        /// <param name="dir"></param>
        public void ExecCdProcess(string dir)
        {
            ExecRemoteProcess("cd", new string[] { dir });
        }

        /// <summary>
        /// 执行授权
        /// </summary>
        /// <param name="dir"></param>
        public void ExecChmodProcess(string chmod,string dir)
        {
            ExecRemoteProcess("chmod", new string[] { chmod, dir });
        }

        /// <summary>
        /// 创建本地进程
        /// </summary>
        /// <param name="FileName">FileName必须环境变量</param>
        /// <returns></returns>
        private void ExecProcess(string FileName, params string[] arg)
        {
            Process p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = FileName;
            p.StartInfo.Arguments = string.Join(" ", arg);
            Console.WriteLine(string.Format("{0} {1}", p.StartInfo.FileName, p.StartInfo.Arguments));
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = true;
            //启动程序
            p.Start();

            p.StandardInput.AutoFlush = true;

            //获取输出信息
            string strOuput = p.StandardOutput.ReadToEnd();
            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();
            Console.WriteLine(strOuput);
        }

        /// <summary>
        /// 执行远程命令
        /// </summary>
        private void ExecRemoteProcess(string cmd, string[] arg)
        {
            string args = string.Join(" ", arg);
            string remotecmd = string.Format("{0} {1}", cmd, args);
            Console.WriteLine(remotecmd);
            SSHHelp.Execute(remotecmd);
        }


        /// <summary>
        /// 强制析构
        /// </summary>
        public void Dispose()
        {
            return;
        }
    }
}
