using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TKBase.Framework.CLI.Supervisor
{
    public class SupervisorCmd
    {

        public SupervisorCmd(string config)
        {
            ConfigurationBuilder bulider = new ConfigurationBuilder();
            bulider.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(config);
            IConfigurationRoot configuration = bulider.Build();
            configuration.Bind(new SSHConfig());
        }


        /// <summary>
        /// 新增守护进程
        /// </summary>
        /// <param name="entity"></param>
        public void Add(SupervisorEntity entity)
        {

        }

        /// <summary>
        /// 重新启动配置中的所有程序
        /// </summary>
        public void Reload(string config)
        {
            using (CliProcess p = new CliProcess())
            {
                p.ExecSupervisorProcess("-c", config, "reload");
            }
            GC.Collect();
        }

        /// <summary>
        /// 配置文件修改后可以使用该命令加载新的配置
        /// </summary>
        public void Update(string config)
        {
            using (CliProcess p = new CliProcess())
            {
                p.ExecSupervisorProcess("-c", config, "update");
            }
            GC.Collect();
        }

        /// <summary>
        /// 启动一个服务
        /// </summary>
        /// <param name="ServiceName"></param>
        public void Start(string config, string ServiceName)
        {
            using (CliProcess p = new CliProcess())
            {
                p.ExecSupervisorProcess("-c",config, "start", ServiceName);
            }
            GC.Collect();
        }

        /// <summary>
        /// 停止一个服务
        /// </summary>
        /// <param name="ServiceName"></param>
        public void Stop(string config, string ServiceName)
        {
            using (CliProcess p = new CliProcess())
            {
                p.ExecSupervisorProcess("-c", config, "stop", ServiceName);
            }
            GC.Collect();
        }

        /// <summary>
        /// 重启一个服务
        /// </summary>
        /// <param name="ServiceName"></param>
        public void Restart(string config, string ServiceName)
        {
            using (CliProcess p = new CliProcess())
            {
                p.ExecSupervisorProcess("-c", config, "restart", ServiceName);
            }
            GC.Collect();
        }
    }
}
