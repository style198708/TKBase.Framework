using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TKBase.Framework.Camera
{
    /// <summary>
    /// 
    /// </summary>
    public class CameraJob : IJob
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Execute(IJobExecutionContext context)
        {
            //Console.Out.WriteLineAsync("Greetings from HelloJob!");
            CameraHelp.GetCameraPic(context.JobDetail.Key.Name);
            return Task.CompletedTask;
        }
    }
}
