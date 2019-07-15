/******************************************************
* author :  Lenny
* email  :  niel@dxy.cn 
* function: 
* time:	2017/8/3 10:15:42 
* clrversion :	4.0.30319.42000
******************************************************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using TKBase.Framework.MRPC.Attributes;
using TKBase.Framework.MRPC.Exceptions;

namespace TKBase.Framework.MRPC
{
    public class RpcConatiner
    {
        public static Dictionary<string, Object> ServiceContainer = new Dictionary<string, Object>();

        public static void Initialize()
        {
            try
            {
                string bastPath = AppDomain.CurrentDomain.BaseDirectory;
                    
                if (Config.MConfig.Services.Count == 0)
                {
                    throw new NotExistException("没有找到服务实现");
                }

                foreach (string path in Config.MConfig.Services)
                {
                    Assembly assembly = Assembly.LoadFrom(bastPath + "/" + path);
                    List<Type> types = assembly.GetTypes().ToList();
                    foreach (var type in types)
                    {
                        MServiceAttribute attribute = type.GetCustomAttribute<MServiceAttribute>();
                        if (attribute != null)
                        {
                            List<Type> interfaces = type.GetInterfaces().ToList();
                            foreach (var iInterface in interfaces)
                            {
                                MServiceAttribute attribute1 = iInterface.GetCustomAttribute<MServiceAttribute>();
                                if (attribute1 != null)
                                {
                                    ServiceContainer.Add(iInterface.FullName, Activator.CreateInstance(type));
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
