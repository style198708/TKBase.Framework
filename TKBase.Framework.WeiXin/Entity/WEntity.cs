using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.WeiXin.Entity
{
    /// <summary>
    /// 统一下订单
    /// </summary>
    public class CreatePreOrder
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 订单总额
        /// </summary>
        public decimal OrderAmount { get; set; }

        /// <summary>
        /// 订单描述
        /// </summary>
        public string OrderContent { get; set; }

        /// <summary>
        /// 终端IP
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 客户端编号
        /// </summary>
        public string OpenId { get; set; }


        /// <summary>
        /// 回调地址
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 附加数据
        /// </summary>
        public string Attach { get; set; }



    }

    /// <summary>
    /// 统一下订单
    /// </summary>
    public class CreateH5PreOrder
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 订单总额
        /// </summary>
        public decimal OrderAmount { get; set; }

        /// <summary>
        /// 订单描述
        /// </summary>
        public string OrderContent { get; set; }

        /// <summary>
        /// 终端IP
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 场景信息
        /// </summary>
        public string Sceneinfo { get; set; }

        /// <summary>
        /// 回调地址
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 附加数据
        /// </summary>
        public string Attach { get; set; }



    }


    /// <summary>
    /// 申请免密支付
    /// </summary>
    public class NoPassCreateOrder : CreatePreOrder
    {
        /// <summary>
        /// 委托代扣协议ID
        /// </summary>
        public string ContractId { get; set; }
    }

    /// <summary>
    /// 查询订单号
    /// </summary>
    public class SeachOrder
    {
        public string OrderCode { get; set; }
    }

    /// <summary>
    /// 付款给用户
    /// </summary>
    public class PayUser
    {
        /// <summary>
        /// 收款人
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 支付订单号
        /// </summary>
        public string PayOrderCode { get; set; }

        /// <summary>
        /// 终端IP
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 收款金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 付款说明
        /// </summary>
        public string Remark { get; set; }

    }
}
