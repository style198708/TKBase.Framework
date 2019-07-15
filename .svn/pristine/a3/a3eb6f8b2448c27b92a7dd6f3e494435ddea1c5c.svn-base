using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKBase.Framework.Encrypt;

namespace TKBase.Framework.WebSite
{
    public class Help
    {
        /// <summary>
        /// 随机算法
        /// </summary>
        /// <returns></returns>
        public string GetNonceStr()
        {
            return MD5Helper.MD5Pay(Guid.NewGuid().ToString(), "UTF-8");

        }

    }
}
