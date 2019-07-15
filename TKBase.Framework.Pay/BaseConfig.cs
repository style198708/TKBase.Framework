using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.Pay
{
    public class BaseConfig
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public static string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public static string MchId { get; set; }

        /// <summary>
        /// 支付回调路径
        /// </summary>
        public static string PayNotifyUrl { get; set; }

        /// <summary>
        /// 微信付款支付
        /// </summary>
        public static string WxUrl { get; set; }

        /// <summary>
        /// 密钥key
        /// </summary>
        public static string Key { get; set; }
    }
}
