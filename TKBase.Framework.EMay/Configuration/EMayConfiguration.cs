using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TKBase.Framework.EMay
{
    public class EMayConfiguration
    {
        /// <summary>
        /// 生成配置
        /// </summary>
        /// <param name="file"></param>
        /// <param name="basepath"></param>
        /// <returns></returns> 
        public static IConfigurationRoot BuildConfiguration(string file, string basepath = null)
        {
            ConfigurationBuilder bulider = new ConfigurationBuilder();
            bulider.SetBasePath(basepath == null ? Directory.GetCurrentDirectory() : basepath);
            bulider.AddJsonFile(file);
            IConfigurationRoot config = bulider.Build();
            return config;
        }

        /// <summary>
        /// 配置映射对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="path"></param>
        public static void Bind<T>(string file, T entity, string key = null)
        {
            IConfigurationRoot config = BuildConfiguration(file);
            if (key == null)
            {
                config.Bind(entity);
            }
            else
            {
                config.Bind(key, entity);
            }
        }
        public static T Bind<T>(string file, string key = null)
        {
            T entity = Activator.CreateInstance<T>();
            Bind<T>(file, entity, key);
            return entity;
        }
    }
}
