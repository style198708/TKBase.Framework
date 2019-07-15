using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.CLI.Dotnet
{
    public class DotNetCmd
    {
        /// <summary>
        /// 清理项目
        /// </summary>
        ///  <param name="FileName">项目解决方案路径</param>
        public void Clean(string FileName)
        {
            using (CliProcess p = new CliProcess())
            {
                p.ExecDotNetProcess("clean", FileName);
            }
            GC.Collect();
        }
        /// <summary>
        /// 更新依赖
        /// </summary>
        ///  <param name="FileName">项目解决方案路径</param>
        public void Restore(string FileName)
        {
            using (CliProcess p = new CliProcess())
            {
                p.ExecDotNetProcess("restore", FileName);
            }
            GC.Collect();
        }
        /// <summary>
        /// 编译生成
        /// </summary>
        ///  <param name="FileName">项目解决方案路径</param>
        public void Build(string FileName)
        {
            using (CliProcess p = new CliProcess())
            {
                p.ExecDotNetProcess("build", FileName);
            }
            GC.Collect();
        }
        /// <summary>
        /// 发布项目
        /// </summary>
        /// <param name="FileName">项目解决方案路径</param>
        public void Publish(string FileName)
        {
            using (CliProcess p = new CliProcess())
            {
                p.ExecDotNetProcess("publish", FileName);
            }
            GC.Collect();
        }
    }
}
