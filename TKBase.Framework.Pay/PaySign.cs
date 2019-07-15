using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TKBase.Framework.Encrypt;

namespace TKBase.Framework.Pay
{
    /// <summary>
    /// 支付签名
    /// </summary>
    public class PaySign
    {

        /// <summary>
        /// 生成签名字符串
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string AddSign(XElement element, string key)
        {
            SortedDictionary<string, string> dic = new SortedDictionary<string, string>();
            foreach (XElement ele in element.Elements())
            {
                if (!string.IsNullOrEmpty(ele.Value))
                    dic.Add(ele.Name.ToString(), ele.Value);
            }
            string sign = AddSign(dic, key);
            return sign;
        }
        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string AddSign(SortedDictionary<string, string> dic, string key)
        {
            if (dic == null)
            {
                return "";
            }
            string signstr = GetSignString(dic, key);
            string sign = MD5Helper.MD5Pay(signstr, "UTF-8");
            return sign;
        }

      
        /// <summary>
        /// 生成签名字符串
        /// </summary>
        /// <param name="sParaTemp"></param>
        /// <returns></returns>
        private static String GetSignString(SortedDictionary<string, string> dic, string key)
        {
            List<string> sign = dic.Where(p => p.Key != "sign" && p.Value != null && p.Value != "null").Select(p => string.Format("{0}={1}", p.Key, p.Value)).ToList();
            return string.Join("&", sign) + "&key=" + key;

        }
    }
}
