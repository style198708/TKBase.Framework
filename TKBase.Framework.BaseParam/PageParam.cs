using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBase.Framework.BaseParam
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class PageParam
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int Page
        {
            get; set;
        }
        /// <summary>
        /// 当前页大小
        /// </summary>
        public int Limit { get; set; }

    }
}
