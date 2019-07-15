using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.WeiXin.Config
{
    /// <summary>
    /// 公众号
    /// </summary>
    public class JsApiConfig : BaseConfig
    {
        /// <summary>
        /// AppSecret
        /// </summary>
        public static string AppSecret { get; set; }

        /// <summary>
        /// 充值回调
        /// </summary>
        public static string WalletRechargeBack { get; set; }

        /// <summary>
        /// 锁支付回调
        /// </summary>
        public static string LockPayNotifyUrl { get; set; }
    }
}
