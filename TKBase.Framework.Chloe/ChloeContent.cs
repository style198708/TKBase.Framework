using System;
using System.Collections.Generic;
using System.Text;
using Chloe;
using Chloe.SqlServer;
using TKBase.Framework.Serializer;
using System.IO;
using Chloe.Entity;
using System.Linq;

namespace TKBase.Framework.Chloe
{
    public class ChloeContent
    {
        public static List<TableConfiguration> TableConfig { get; set; }

        static ChloeContent()
        {
            if (TableConfig == null)
                TableConfig = (List<TableConfiguration>)SerializerXml.LoadSettings(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TableConfig.xml"), typeof(List<TableConfiguration>));
        }

        /// <summary>
        /// 取数据库
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IQuery<T> Create<T>() where T : class
        {
            string ConfigName = GetConfigName<T>();
            TableConfiguration configuration = TableConfig.Where(p => p.Name == ConfigName).FirstOrDefault();
            if (configuration != null)
            {
                return new MsSqlContext(configuration.ConnectString).Query<T>();
            }
            return null;
        }

        /// <summary>
        /// 取数据库节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetConfigName<T>()
        {
            Type type = typeof(T);
            TableAttribute table = (TableAttribute)type.GetCustomAttributes(false)[0];
            return "";
        }
    }
}
