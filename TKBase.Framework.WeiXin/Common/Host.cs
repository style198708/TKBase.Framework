using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.WeiXin.Common
{
    /// <summary>
    ///  公共类
    /// </summary>
    public class Host
    {

        #region 会员信息

        /// <summary>
        /// 主站地址
        /// </summary>
        public static string HostUrl = "https://api.weixin.qq.com/";

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        public static string BaseAccessToken { get { return string.Format("{0}cgi-bin/token", HostUrl); } }


        /// <summary>
        /// 获取AccessToken
        /// </summary>
        public static string AccessToken { get { return string.Format("{0}oauth2/access_token", HostUrl); } }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        public static string UserInfo { get { return string.Format("{0}sns/userinfo", HostUrl); } }

        /// <summary>
        /// 获到Ticket
        /// </summary>
        public static string Ticket { get { return string.Format("{0}cgi-bin/ticket/getticket", HostUrl); } }

        #endregion

        #region  支付信息

        /// <summary>
        /// 统一下单接口
        /// </summary>
        public static string CreatePreOrder { get { return string.Format("{0}pay/unifiedorder", HostUrl); } }

        /// <summary>
        /// 查询单接口
        /// </summary>
        public static string SearchOrder { get { return string.Format("{0}pay/orderquery", HostUrl);  } }

        /// <summary>
        /// 企业付款给用户
        /// </summary>
        public static string PayUser { get { return string.Format("{0}mmpaymkttransfers/promotion/transfers", HostUrl); } }

        /// <summary>
        /// 支付中签约
        /// </summary>
        public static string PayContract { get { return string.Format("{0}pay/contractorder", HostUrl); } }

        /// <summary>
        /// 申请免密支付
        /// </summary>
        public static string NoPassUser { get { return string.Format("{0}pay/pappayapply", HostUrl); } }

        #endregion

        #region 消息模块

        public static string Message { get { return string.Format("{0}cgi-bin/message/template/send", HostUrl); } }

        #endregion

    }
}
