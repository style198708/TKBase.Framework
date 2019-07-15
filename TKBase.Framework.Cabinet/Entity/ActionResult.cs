﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.Cabinet
{

    /// <summary>
    ///  基础信息
    /// </summary>
    public class BaseAction
    {
        /// <summary>
        /// 语言播报
        /// </summary>
        public string Msg { get; set; }
    }

    /// <summary>
    /// App/ 微信开门
    /// </summary>
    public class OpenCabinetAction: BaseAction
    {
        public string ShelfCode { get; set; }
    }
    
    /// <summary>
    /// 开锁
    /// </summary>
    public class OpenLockAction:BaseAction
    {
        /// <summary>
        /// 锁集合
        /// </summary>
        public List<string> LockNum { get; set; }

        /// <summary>
        /// 商品条码
        /// </summary>
        public string ProductSn { get; set; }

        /// <summary>
        /// 供货商编码
        /// </summary>
        public string SupplierCode { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
    }

    /// <summary>
    /// 微信开锁
    /// </summary>
    public class WxOpenLockAction: BaseAction
    {
        /// <summary>
        /// 锁集合
        /// </summary>
        public List<string> LockNum { get; set; }
    }

    /// <summary>
    /// 中控检测
    /// </summary>
    public class LockCheckAction: BaseAction
    {
        /// <summary>
        /// 中控编号
        /// </summary>
        public string LockNumber { get; set; }

        /// <summary>
        /// 中控状态
        /// </summary>
        public int StatusFlag { get; set; }
    }

}