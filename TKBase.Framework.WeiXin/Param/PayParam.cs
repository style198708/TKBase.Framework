using System;
using System.Collections.Generic;
using System.Text;
using TKBase.Framework.Encrypt;
using TKBase.Framework.WeiXin.Config;

namespace TKBase.Framework.WeiXin.Param
{
    #region  微信支付基类
    /// <summary>
    /// 
    /// </summary>
    public class Base
    {
        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 随机码
        /// </summary>
        public string nonce_str { get { return MD5Helper.MD5Pay(Guid.NewGuid().ToString(), "UTF-8"); } }
    }


    public class PayBase: Base
    {
        /// <summary>
        /// Appid
        /// </summary>
        public string appid { get { return JsApiConfig.AppId; } } 
        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id { get { return JsApiConfig.MchId; } }

    }
    public class WBase : PayBase
    {
        /// <summary>
        /// 签名类型
        /// </summary>
        public string sign_type { get { return "MD5"; } }
    }
    public class CBase: Base
    {
        /// <summary>
        /// Appid
        /// </summary>
        public string mch_appid { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string mchid { get; set; }


    }

    #endregion

    #region 支付接口参数，字段说明参照微信官方

    /// <summary>
    /// 统一下单接口
    /// </summary>
    public class CreatePreOrderParam : WBase
    {
        public string body { get; set; }
        public string device_info { get; set; }
        public string out_trade_no { get; set; }
        public string fee_type { get; set; }
        public string total_fee { get; set; }
        public string spbill_create_ip { get; set; }
        public string time_start { get; set; }
        public string notify_url { get; set; }
        public string trade_type { get; set; }
        public string attach { get; set; }
        public string openid { get; set; }

    }

    /// <summary>
    /// 查询单接口
    /// </summary>
    public class SearchOrderParam : WBase
    {
        public string out_trade_no { get; set; }
    }

    /// <summary>
    /// 企业付款给用户
    /// </summary>
    public class PayUserParam : CBase
    {
        public string device_info { get; set; }
        public string partner_trade_no { get; set; }
        public string openid { get; set; }
        public string check_name { get; set; }
        public string amount { get; set; }
        public string desc { get; set; }
        public string spbill_create_ip { get; set; }
    }

    /// <summary>
    /// 免密支付
    /// </summary>
    public class ContractParam : PayBase
    {
        public string contract_mchid { get; set; }
        public string contract_appid { get; set; }
        public string out_trade_no { get; set; }
        public string device_info { get; set; }
        public string body { get; set; }
        public string notify_url { get; set; }
        public string total_fee { get; set; }
        public string spbill_create_ip { get; set; }
        public string trade_type { get; set; }
        public string openid { get; set; }
        public string plan_id { get; set; }
        public string contract_code { get; set; }
        public string request_serial { get; set; }
        public string contract_display_account { get; set; }
        public string contract_notify_url { get; set; }

        public string attach { get; set; }

    }

    /// <summary>
    /// 免密申请支付
    /// </summary>
    public class NoPassUserParam: WBase
    {
        public string body { get; set; }
        public string out_trade_no { get; set; }
        public string fee_type { get; set; }
        public string total_fee { get; set; }
        public string spbill_create_ip { get; set; }
        public string notify_url { get; set; }
        public string trade_type { get; set; }
        public string contract_id { get; set; }
        public string attach { get; set; }
    }

    #endregion

}
