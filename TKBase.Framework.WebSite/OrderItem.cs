using System;
using System.Collections.Generic;
using System.Text;
using TKBase.Framework.Dapper;

namespace TKBase.Framework.WebSite
{
    /// <summary>
    /// 订单详情
    /// </summary>
    [TableMapping(ConfigName = "XCKJ_Project")]
    public class OrderItem
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 货品编号
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// 货品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        public decimal RetailPrice { get; set; }
        /// <summary>
        /// 实际价格
        /// </summary>
        public decimal SellingPrice { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Amount { get; set; }
    }
}
