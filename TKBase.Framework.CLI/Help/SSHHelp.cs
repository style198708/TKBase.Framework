using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.CLI
{
    /// <summary>
    /// SSH命令执行
    /// </summary>
    public class SSHHelp
    {
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="Cmd"></param>
        public static void Execute(string Cmd)
        {
            using (var client = new SshClient(SSHConfig.Host, SSHConfig.User, SSHConfig.PassWord))
            {
                try
                {
                    client.Connect();
                    System.Console.WriteLine(client.RunCommand(Cmd).Execute());
                    client.Disconnect();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

 
    }
}
