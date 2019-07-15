﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.EMay
{
    public static class EMayExtensions
    {
        /// <summary>
        /// 注册亿美短信
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddEMay(this IServiceCollection services)
        {
            EMay.EMayHelp.InitConfig();
            return services;
        }
        /// <summary>
        /// 注册亿美短信
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddEMay(this IServiceCollection services, string config)
        {
            EMay.EMayHelp.InitConfig(config);
            return services;
        }

    }
}
