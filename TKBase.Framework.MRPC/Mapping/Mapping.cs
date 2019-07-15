using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TKBase.Framework.MRPC.Mapping
{
    public class Mapping
    {
        /// <summary>
        /// 实体映射（只针对简单实体）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static F Map<T, F>(T entity) where F : new()
        {
            F model = new F();
            var type = model.GetType();
            foreach (PropertyInfo p in type.GetProperties())
            {
                try
                {
                    p.SetValue(model, entity.GetType().GetProperty(p.Name).GetValue(entity));
                }
                catch
                {
                    continue;
                }
            }
            return model;
        }
    }
}
