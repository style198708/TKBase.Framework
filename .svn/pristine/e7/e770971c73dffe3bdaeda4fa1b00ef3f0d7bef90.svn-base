using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKBase.Framework.BaseResult
{
    /// <summary>
    /// 统一返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataResultList<T> where T : class
    {
        public DataResultList()
        {
            this.ResultList = new List<T>();
        }
        /// <summary>
        /// 数据集合
        /// </summary>
        public IList<T> ResultList { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }
        public int TotalPage
        {
            get
            {
                return TotalRecord % PageSize == 0 ? TotalRecord / PageSize : TotalRecord / PageSize + 1;
            }
        }
    }
}
