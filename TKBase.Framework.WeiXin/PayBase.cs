using System.Net;
using System.Text;
using System.Xml.Linq;
using TKBase.Framework.Helper;
using TKBase.Framework.WeiXin.Common;
using TKBase.Framework.WeiXin.Config;
using TKBase.Framework.WeiXin.Param;

namespace TKBase.Framework.WeiXin
{
    public class PayBase
    {
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        internal static XElement Post(string Url, XElement element, string WxUrl, CertificateEntity entity = null)
        {
            string posturl = string.Format("{0}{1}", WxUrl, Url);
            var data = element.ToString();
            var formDataBytes = data == null ? new byte[0] : Encoding.UTF8.GetBytes(data);
            HttpWebResponse response = null;
            byte[] result = HttpHelper.SendRequestData(posturl, formDataBytes, ref response, entity);
            string reslutxml = System.Text.Encoding.UTF8.GetString(result);
            XDocument resultDod = XDocument.Parse(reslutxml);
            return resultDod.Element("xml");
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="formdata"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        internal static XElement Post(string Url, string formdata, CertificateEntity entity = null)
        {
            HttpWebResponse response = null;
            var formDataBytes = formdata == null ? new byte[0] : Encoding.UTF8.GetBytes(formdata);
            byte[] result = HttpHelper.SendRequestData(Url, formDataBytes, ref response, entity);
            string reslutxml = System.Text.Encoding.UTF8.GetString(result);
            XDocument resultDod = XDocument.Parse(reslutxml);
            return resultDod.Element("xml");
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Url"></param>
        /// <param name="entity"></param>
        /// <param name="certificate"></param>
        /// <returns></returns>
        internal static XElement Post<T>(string Url, T entity, CertificateEntity certificate = null) where T : Base
        {
            entity.sign= PaySign.AddSign(entity, JsApiConfig.Key);
            string formdata = Serializer.SerializerXml.Serializer(entity);
            return Post(Url, formdata, certificate);
        }
    }
}
