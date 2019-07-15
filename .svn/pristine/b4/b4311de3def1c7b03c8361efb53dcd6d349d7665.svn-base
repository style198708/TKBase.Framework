using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TKBase.Framework.Configuration;
using TKBase.Framework.Serializer;

namespace TKBase.Framework.Redis
{
    public static class RedisExtensions
    {
        public static IServiceCollection AddRedis(this IServiceCollection services)
        {
            RedisEntityConfig redisconfig = Config.Bind<RedisEntityConfig>("Middleware.json", "Redis");
            InitRedis(ref services, redisconfig);
            return services;
        }

        /// <summary>
        /// 注册Redis中间件支持集群
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddRedis(this IServiceCollection services, string config)
        {
            RedisEntityConfig redisconfig = Config.Bind<RedisEntityConfig>(config);
            InitRedis(ref services, redisconfig);
            return services;
        }

        private static void InitRedis(ref IServiceCollection services, RedisEntityConfig redisconfig)
        {
            CSRedisClient client = null;
            if (redisconfig.RedisMode == "Single")
            {
                client = new CSRedisClient(redisconfig.RedisConnectionSingle);
            }
            else if (redisconfig.RedisMode == "Multiple")
            {
                client = new CSRedisClient(null, redisconfig.RedisConnectionMultiple.ToArray());
            }
            else
            {
                throw new Exception("Redis初始化异常!,请检查配置文件");
            }
            RedisHelper.Initialization(client, value => SerializerJson.SerializeObject(value), deserialize: (data, type) => SerializerJson.DeserializeObject(data, type));
            services.AddSingleton<IDistributedCache>(new TKBase.Framework.Redis.CSRedisCache(RedisHelper.Instance));
        }

    }
}
