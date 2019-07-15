using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TKBase.Framework.Extension
{
    public static class ListExtension
    {
        /// <summary>
        /// 集合有值判断
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool HasListValue<T>(this List<T> list) where T : class
        {
            return list != null && list.Count > 0;
        }
        public static List<T> Add<T>(this List<T> item, params T[] param)
        {
            return item.Union(param).ToList();
        }

        /// <summary>
        /// 集合中随机取一个
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GetSing(this List<string> item)
        {
            Random random = new Random();
            int index = random.Next(0, item.Count() - 1);
            string code = item[index];
            item.Remove(code);
            return code;
        }

    }
}
