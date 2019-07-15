using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TKBase.Framework.Serializer
{
    /// <summary>
    /// JSON序列化处理方法类
    /// </summary>
    public class SerializerJson
    {
        /// <summary>
        /// 序列化成字符串
        /// </summary>
        /// <param name="obj">除了DataTable,Color等类型不能序列化之外,基本其它都能序列化,未亲自测试</param>
        /// <returns></returns>
        public static string SerializeObject(object obj)
        {
            JsonSerializerSettings settings = DefaultJsonSettings();
            return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.None, settings);
        }


        /// <summary>
        /// 反序列化成实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string value)
        {
            JsonSerializerSettings settings = DefaultJsonSettings();
            return JsonConvert.DeserializeObject<T>(value, settings);
        }

        /// <summary>
        /// 类型序列化成实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object DeserializeObject(string value, System.Type type)
        {
            JsonSerializerSettings settings = DefaultJsonSettings();
            return JsonConvert.DeserializeObject(value, type);
        }
        /// <summary>
        /// 序列化转化方式
        /// </summary>
        /// <returns></returns>
        public static JsonSerializerSettings DefaultJsonSettings()
        {

            JsonSerializerSettings json = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
                //DefaultValueHandling = DefaultValueHandling.Ignore
            };
            json.Converters.Clear();
            json.Converters.Add(new IsoDateTimeConverter()
            {
                DateTimeFormat = "yyyy'-'MM'-'dd HH:mm:ss"
            });
            return json;
        }


        #region byte序列化
        /// <summary>
        /// 序列化成字节流
        /// </summary>
        /// <typeparam name="T">泛型实体</typeparam>
        /// <param name="entity">具体实体</param>
        /// <returns>byte字节流</returns>
        private byte[] SerializeObject<T>(T entity)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                xs.Serialize(ms, entity);
                byte[] bytes = ms.ToArray();
                return bytes;
            }
        }

        /// <summary>
        /// 反序列化成实体
        /// </summary>
        /// <typeparam name="T">具体实体</typeparam>
        /// <param name="data">byte字节流</param>
        /// <returns>返回一个实体</returns>
        private T DeserializeObject<T>(byte[] data)
        {
            string json = Encoding.UTF8.GetString(data);
            T entity = DeserializeObject<T>(json);
            return entity;
        }
        #endregion

    }
}
