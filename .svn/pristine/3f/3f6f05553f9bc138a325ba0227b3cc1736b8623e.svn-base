using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace TKBase.Framework.Extension
{
    public static class EntityExtension
    {
        /// <summary>
        /// 实体转化为的排序数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SortedDictionary<string,string> ToSortedDictionary<T>(this T entity) where T:class
        {
            SortedDictionary<string, string> keys = new SortedDictionary<string, string>();   
            Type type = entity.GetType();
            foreach (PropertyInfo info in type.GetProperties())
            {
                keys.Add(info.Name, info.GetValue(entity).ToString());

            }

            return keys;
        }
    }
}
