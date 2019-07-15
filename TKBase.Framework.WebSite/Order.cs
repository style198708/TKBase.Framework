﻿using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using TKBase.Framework.Dapper;
using TKBase.Framework.Elasticsearch;

namespace TKBase.Framework.WebSite
{

    public class Tweet:ElasticsearchBase
    {
        public string User { get; set; }
        public string Message { get; set; }

    }


    public class Test
    {
        public int Type { get; set; }
    }

    /// <summary>
    /// 订单
    /// </summary>
    [TableMapping(ConfigName = "XCKJ_Project")]
    public class Order : BaseEntity
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 订单时间
        /// </summary>
        public DateTime OrderTime { get; set; }
        /// <summary>
        /// 货品总数
        /// </summary>
        public int ProductCount { get; set; }
        /// <summary>
        /// 总价格
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 供货商编号（供货商MemberName）
        /// </summary>
        public string SupplierCode { get; set; }
        /// <summary>
        /// 支付状态(1待支付，2已支付，3已作废)
        /// </summary>
        public int PayStatusFlag { get; set; }


    }
}
