using System;
using TKBase.Framework.Dapper;

namespace TKBase.Framework.WebSite
{
    /// <summary>
    /// 上架记录表
    /// </summary>
    [TableMapping(ConfigName = "XCKJ_Project")]
    public class ProductShelfRecord:BaseEntity
    {
        /// <summary>
        /// 上架编码
        /// </summary>
        public string ShelfCode { get; set; }

        /// <summary>
        /// 柜子编号
        /// </summary>
        public string CabinetCode { get; set; }

        /// <summary>
        /// 上架人
        /// </summary>
        public string ShelfMember { get; set; }

        /// <summary>
        /// 上架时间
        /// </summary>
        public DateTime ShelfTime { get; set; }

        /// <summary>
        /// 状态（1预上架，2待上架，3已上架）
        /// </summary>
        public int StatusFlag { get; set; }
    }
}
