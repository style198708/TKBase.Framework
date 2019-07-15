using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TKBase.Framework.Configuration;

namespace TKBase.Framework.WebApi
{
    /// <summary>
    /// Kestrel服务
    /// </summary>
    public class KestrelHost 
    {
        /// <summary>
        /// 启动Kestrel服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hosting"></param>
        public static void Start<T>(string hosting) where T : class
        { 
            IConfigurationRoot config = Config.BuildConfiguration(hosting);
            var host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseKestrel()
                .UseStartup<T>()
                .Build();
            host.Run();
        }
    }
}
