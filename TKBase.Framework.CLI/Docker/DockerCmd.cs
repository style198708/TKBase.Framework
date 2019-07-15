using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TKBase.Framework.CLI.Docker
{
    /// <summary>
    /// Docker 命令
    /// </summary>
    public class DockerCmd
    {
        /// <summary>
        /// 通过shell生成镜像
        /// </summary>
        /// <param name="Images">镜像名称</param>
        public void BulidImage(string Images,string UpdateFile)
        {
            using (CliProcess p = new CliProcess())
            {


                //此外 '.' 不可省略
                p.ExecDockerProcess("build", "-f",Path.Combine(UpdateFile, "Dockerfile"),  "-t", string.Format("{0} .", Images));
            }
            GC.Collect();
        }

        /// <summary>
        /// 启动镜像
        /// </summary>
        public void BuildContainer(string Images,int Port, string CName)
        {
            //docker run --name=aspnetcoredocker -p 7777:80 -d  aspnetcoredocker
            using (CliProcess p = new CliProcess())
            {
                //生成镜像 镜像默认是80
                p.ExecDockerProcess("run", string.Format("--name={0}", CName),"-p", string.Format("{0}:80", Port),"-d", Images);
            }
            GC.Collect();
        }

    }
}
