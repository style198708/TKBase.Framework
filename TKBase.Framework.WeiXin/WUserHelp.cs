using System.Security.Cryptography;
using System.Text;
using TKBase.Framework.RestSharp;
using TKBase.Framework.WeiXin.Common;
using TKBase.Framework.WeiXin.Config;
using TKBase.Framework.WeiXin.Param;
using TKBase.Framework.WeiXin.Serializer;

namespace TKBase.Framework.WeiXin
{
    /// <summary>
    ///  微信用户帮助
    /// </summary>
    public class WUserHelp
    {
        /// <summary>
        /// 普通获取Token
        /// </summary>
        /// <returns></returns>
        public static AccessToken GetAccessToken()
        {
            RestClient client = new RestClient(Host.BaseAccessToken);
            IRestRequest request = new RestRequest(Method.GET);
            request.AddParameter("appid", JsApiConfig.AppId);
            request.AddParameter("secret", JsApiConfig.AppSecret);
            request.AddParameter("grant_type", "client_credential");
            IRestResponse response = client.Execute(request);
            AccessToken token = SerializerJson.DeserializeObject<AccessToken>(response.Content); ;
            return token;
        }


        /// <summary>
        /// 微信网页能过Code授权取Token
        /// </summary>
        public static AccessToken GetAccessToken(string Code)
        {
            RestClient client = new RestClient(Host.AccessToken);
            IRestRequest request = new RestRequest(Method.GET);
            request.AddParameter("appid", JsApiConfig.AppId);
            request.AddParameter("secret", JsApiConfig.AppSecret);
            request.AddParameter("code", Code);
            request.AddParameter("grant_type", "authorization_code");
            IRestResponse response = client.Execute(request);
            AccessToken token = SerializerJson.DeserializeObject<AccessToken>(response.Content); ;
            return token;
        }

        /// <summary>
        /// 获到用户信息
        /// </summary>
        public static UserInfo GetUser(string Code)
        {
            AccessToken token = GetAccessToken(Code);
            RestClient userclient = new RestClient(Host.UserInfo);
            IRestRequest userrequest = new RestRequest(Method.GET);
            userrequest.AddParameter("access_token", token.access_token);
            userrequest.AddParameter("openid", token.openid);
            userrequest.AddParameter("lang", "zh_CN");
            IRestResponse userresponse = userclient.Execute(userrequest);
            UserInfo userInfo = SerializerJson.DeserializeObject<UserInfo>(userresponse.Content);
            string openid = userInfo.openid;
            if (userInfo.errcode == 40029)
            {
                return null;
            }
            return userInfo;
        }

        /// <summary>
        /// 获到Ticket 
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public static Ticket GetTicket(string Code)
        {
            AccessToken token = GetAccessToken(Code);
            RestClient client = new RestClient(Host.Ticket);
            IRestRequest request = new RestRequest(Method.GET);
            request.AddParameter("access_token", token.access_token);
            request.AddParameter("type", "jsapi");
            IRestResponse response1 = client.Execute(request);
            Ticket ticket = SerializerJson.DeserializeObject<Ticket>(response1.Content);
            return ticket;
        }

        /// <summary>
        /// 签名算法
        ///本代码来自开源微信SDK项目：https://github.com/night-king/weixinSDK
        /// </summary>
        /// <param name="jsapi_ticket">jsapi_ticket</param>
        /// <param name="noncestr">随机字符串(必须与wx.config中的nonceStr相同)</param>
        /// <param name="timestamp">时间戳(必须与wx.config中的timestamp相同)</param>
        /// <param name="url">当前网页的URL，不包含#及其后面部分(必须是调用JS接口页面的完整URL)</param>
        public static string GetSignature(string Code,string Url)
        {     
            Ticket ticket = GetTicket(Code);
            var string1Builder = new StringBuilder();
            string1Builder.Append("jsapi_ticket=").Append(ticket.ticket).Append("&")
                          .Append("noncestr=").Append("SgrgjIFTOiMfxWA").Append("&")
                          .Append("timestamp=").Append(1543816352).Append("&")
                          .Append("url=").Append(Url.IndexOf("#") >= 0 ? Url.Substring(0, Url.IndexOf("#")) : Url);
            string str = string1Builder.ToString();
            var buffer = Encoding.UTF8.GetBytes(str);
            var data = SHA1.Create().ComputeHash(buffer);

            var sb = new StringBuilder();
            foreach (var t in data)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
