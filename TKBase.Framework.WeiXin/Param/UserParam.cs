using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.WeiXin.Param
{
    /// <summary>
    /// 微信结果基本类
    /// </summary>
    public class JsApiBase
    {
        public int errcode { get; set; }

        public string errmsg { get; set; }
    }

    /// <summary>
    /// 根据Code获取Token
    /// </summary>
    public class AccessToken : JsApiBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int expires_in { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string refresh_token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string scope { get; set; }
    }


    public class Ticket : JsApiBase
    {
        public string ticket { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int expires_in { get; set; }

    }

    /// <summary>
    /// 字段说明参照官方文档
    /// </summary>
    public class UserInfo : JsApiBase
    {
        public string openid { get; set; }

        public string nickname { get; set; }

        public string sex { get; set; }

        public string province { get; set; }

        public string city { get; set; }

        public string country { get; set; }

        public string headimgurl { get; set; }

        public List<string> privilege { get; set; }

        public string unionid { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class ConfigResult
    {
        public string appId { get; set; }
        /// <summary>
        /// 时间戳，自1970年以来的秒数
        /// </summary>
        public long timeStamp { get; set; }
        /// <summary>
        /// 随机串
        /// </summary>
        public string nonceStr { get; set; }

        /// <summary>
        /// 微信签名
        /// </summary>
        public string signature { get; set; }

    }

}
