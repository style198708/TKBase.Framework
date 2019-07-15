using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace TKBase.Framework.WeiXin.Serializer
{
    /// <summary>
    /// XML序列化/反序列化
    /// 作者：Dylan
    /// </summary>
    public class SerializerXml
    {

        /// <summary>
        ///  仅为微信支付
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string Serializer<T>(T entity) where T : class
        {
            XElement xElement = new XElement("xml");
            Type type = typeof(T);
            foreach (var p in type.GetProperties())
            {
                xElement.Add(new XElement(p.Name, new XCData(p.GetValue(p.Name) == null ? "" : p.GetValue(p.Name).ToString())));
            }
            return xElement.ToString();
        }
    }
}
