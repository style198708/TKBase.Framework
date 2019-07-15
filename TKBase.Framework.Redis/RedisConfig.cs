using System.Collections.Generic;
using TKBase.Framework.Configuration;

namespace TKBase.Framework.Redis
{
    /// <summary>
    /// CO
    /// </summary>
    public  class RedisConfig
    {
        public static string RedisMode { get; set; }
        public static string RedisConnectionSingle { get; set; }
        public static List<string> RedisConnectionMultiple { get; set; }
        static RedisConfig()
        {
            RedisEntityConfig redisConfig = Config.Bind<RedisEntityConfig>("Redis.json");
            if (redisConfig != null)
            {
                RedisMode = redisConfig.RedisMode;
                RedisConnectionSingle = redisConfig.RedisConnectionSingle;
                RedisConnectionMultiple = redisConfig.RedisConnectionMultiple;
            }
        }
    }
}
