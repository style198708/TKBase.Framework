using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.WebSite
{
    public class BaseEntity
    {
        /// <summary>
        /// 编号 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? CreateBy { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public bool? DeleteFlag { get; set; }
    }
}
