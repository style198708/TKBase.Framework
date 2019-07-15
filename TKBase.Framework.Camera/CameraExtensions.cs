using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TKBase.Framework.Configuration;

namespace TKBase.Framework.Camera
{
    public static class CameraExtensions
    {
        /// <summary>
        /// 初始化微信支付
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddCamera(this IServiceCollection services)
        {
            Config.Bind<CameraConfig>("Service.json", "Camera");
            return services;
        }

        /// <summary>
        /// 初始化微信支付
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddCamera(this IServiceCollection services, string config)
        {
            Config.Bind<CameraConfig>(config);
            return services;
        }
    }
}
