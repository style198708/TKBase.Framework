using System;
using System.Collections.Generic;
using TKBase.Framework.Serializer;

namespace TKBase.Framework.Redis
{
    /// <summary>
    /// 缓存管理
    /// 1.要可以查看所有的缓存
    /// 2.要可以管理缓存中的数据，如清空，删除等
    /// 3.可以预先加载
    /// </summary>
    public class RedisManager
    {
        private int DbNum { get; }
        public string CustomKey;
        public CSRedisClient Csredis { get; set; }

        #region 构造函数

        public RedisManager(int dbNum = 0)
        {
            if (RedisConfig.RedisMode == "Single")
            {
                Csredis = new CSRedisClient(RedisConfig.RedisConnectionSingle);
            }
            else if (RedisConfig.RedisMode == "Multiple")
            {
                Csredis = new CSRedisClient(null, RedisConfig.RedisConnectionMultiple.ToArray());
            }
            else
            {
                throw new Exception("Redis初始化异常!,请检查配置文件");
            }


        }

        #endregion 构造函数

        #region String

        #region 同步方法

        /// <summary>
        /// 保存单个key value
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <param name="value">保存的值</param>
        /// <param name="expiry">过期时间</param>
        /// <returns></returns>
        public bool StringSet(string key, string value, TimeSpan? expiry = default(TimeSpan?))
        {
            return RedisHelper.Set(key, value, expiry.Value.Milliseconds);
        }

        /// <summary>
        /// 保存一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public bool StringSet<T>(string key, T obj, TimeSpan? expiry = default(TimeSpan?)) where T : class
        {
            return StringSet(key, SerializerJson.SerializeObject(obj), expiry);
        }

        /// <summary>
        /// 保存一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        public bool StringSet<T>(string key, T obj, DateTime expiry) where T : class
        {
            return StringSet<T>(key, obj, expiry - DateTime.Now);
        }

        /// <summary>
        /// 获取单个key的值
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <returns></returns>
        public string StringGet(string key)
        {
            return RedisHelper.Get(key);
        }


        /// <summary>
        /// 获取一个key的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T StringGet<T>(string key)
        {
            return SerializerJson.DeserializeObject<T>(StringGet(key));

        }

        ///// <summary>
        ///// 为数字增长val
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="val">可以为负</param>
        ///// <returns>增长后的值</returns>
        //public double StringIncrement(string key, double val = 1)
        //{
        //    //key = AddSysCustomKey(key);
        //    //return Do(db => db.StringIncrement(key, val));
        //    return 0;
        //}

        ///// <summary>
        ///// 为数字减少val
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="val">可以为负</param>
        ///// <returns>减少后的值</returns>
        //public double StringDecrement(string key, double val = 1)
        //{
        //    //key = AddSysCustomKey(key);
        //    //return Do(db => db.StringDecrement(key, val));
        //    return 0;
        //}

        #endregion 同步方法


        #endregion String


        #region key

        /// <summary>
        /// 删除单个key
        /// </summary>
        /// <param name="key">redis key</param>
        /// <returns>是否删除成功</returns>
        public bool KeyDelete(string key)
        {
            return RedisHelper.Remove(key) > 0;
        }

        /// <summary>
        /// 删除多个key
        /// </summary>
        /// <param name="keys">rediskey</param>
        /// <returns>成功删除的个数</returns>
        public long KeyDelete(List<string> keys)
        {
            return RedisHelper.Remove(keys.ToArray());
        }

        /// <summary>
        /// 判断key是否存储
        /// </summary>
        /// <param name="key">redis key</param>
        /// <returns></returns>
        public bool KeyExists(string key)
        {
            return RedisHelper.Exists(key);
        }

        /// <summary>
        /// 重新命名key
        /// </summary>
        /// <param name="key">就的redis key</param>
        /// <param name="newKey">新的redis key</param>
        /// <returns></returns>
        //public bool KeyRename(string key, string newKey)
        //{
        //    //key = AddSysCustomKey(key);
        //    //return Do(db => db.KeyRename(key, newKey));
        //    return true;
        //}

        /// <summary>
        /// 设置Key的时间
        /// </summary>
        /// <param name="key">redis key</param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        //public bool KeyExpire(string key, TimeSpan? expiry = default(TimeSpan?))
        //{
        //    key = AddSysCustomKey(key);
        //    return Do(db => db.KeyExpire(key, expiry));
        //}

        /// <summary>
        /// 获取所有KEY
        /// </summary>
        /// <returns></returns>
        //public List<string> GetAllCacheKeys()
        //{
        //    try
        //    {
        //        var result = new List<string>();
        //        var endpoints = _conn.GetEndPoints(true);
        //        foreach (var endpoint in endpoints)
        //        {
        //            var server = _conn.GetServer(endpoint);
        //            result.AddRange(server.Keys(DbNum).Select(x => x.ToString()));
        //        }
        //        return result.Distinct().ToList();
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// 获取所有KEY-Value
        /// </summary>
        /// <returns></returns>
        //public IDictionary<string, object> GetAll()
        //{
        //    try
        //    {
        //        var result = new Dictionary<string, object>();
        //        IDatabase idb = _conn.GetDatabase(DbNum);
        //        var endpoints = _conn.GetEndPoints(true);
        //        //Logger.Info("DbNum:" + DbNum);
        //        // Logger.Info("Endpoints:" + endpoints.Count());
        //        foreach (var endpoint in endpoints)
        //        {
        //            //Logger.Info("GetAll:" + endpoint.GetType().ToString());
        //            var server = _conn.GetServer(endpoint);
        //            //Logger.Info("server:" + server.Keys(DbNum).Count());
        //            foreach (var item in server.Keys(DbNum))
        //            {
        //                //Logger.Info("item" + item.ToString());

        //                result.Add(item.ToString(), idb.StringGet(item.ToString()));
        //            }
        //        }
        //        return result;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}


        #endregion key

        #region 发布订阅

        /// <summary>
        /// Redis发布订阅  订阅
        /// </summary>
        /// <param name="subChannel"></param>
        /// <param name="handler"></param>
        //public void Subscribe(string subChannel, Action<RedisChannel, RedisValue> handler = null)
        //{
        //    ISubscriber sub = _conn.GetSubscriber();
        //    sub.Subscribe(subChannel, (channel, message) =>
        //    {
        //        if (handler == null)
        //        {
        //            Console.WriteLine(subChannel + " 订阅收到消息：" + message);
        //        }
        //        else
        //        {
        //            handler(channel, message);
        //        }
        //    });
        //}

        /// <summary>
        /// Redis发布订阅  发布
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channel"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        //public long Publish<T>(string channel, T msg) where T : class
        //{
        //    ISubscriber sub = _conn.GetSubscriber();
        //    return sub.Publish(channel, ConvertJson(msg));
        //}

        /// <summary>
        /// Redis发布订阅  取消订阅
        /// </summary>
        /// <param name="channel"></param>
        //public void Unsubscribe(string channel)
        //{
        //    ISubscriber sub = _conn.GetSubscriber();
        //    sub.Unsubscribe(channel);
        //}

        /// <summary>
        /// Redis发布订阅  取消全部订阅
        /// </summary>
        //public void UnsubscribeAll()
        //{
        //    ISubscriber sub = _conn.GetSubscriber();
        //    sub.UnsubscribeAll();
        //}

        #endregion 发布订阅


    }
}
