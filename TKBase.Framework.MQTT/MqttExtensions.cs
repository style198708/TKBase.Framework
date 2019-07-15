﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TKBase.Framework.Configuration;

namespace TKBase.Framework.MQTT
{
    public static class MqttExtensions
    {
        /// <summary>
        /// 初始化微信支付
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddWebSocket(this IServiceCollection services)
        {
            Config.Bind<WebSocketConfig>("Middleware.json", "MqttClientWebSocketOptions");
            return services;
        }
        /// <summary>
        /// 初始化微信支付
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddWebSocket(this IServiceCollection services, string config)
        {

            Config.Bind<WebSocketConfig>(config);
            return services;
        }

    }
}
