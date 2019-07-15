using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TKBase.Framework.Help
{
    public class EnumHelper
    {
        /// <summary>
        /// 程序集
        /// </summary>
        /// <param name="Assmly"></param>
        /// <param name="file"></param>
        public void EnumToJson(string Ass, string file)
        {
            StringBuilder builder = new StringBuilder();
            Type[] types = Assembly.Load("TestReflection").GetTypes();
            foreach (Type type in types)
            {
               foreach(FieldInfo info in type.GetFields())
                {

                }

            }
        }
    }
}
