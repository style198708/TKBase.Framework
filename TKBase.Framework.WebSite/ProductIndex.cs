using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKBase.Framework.Elasticsearch;

namespace TKBase.Framework.WebSite
{
    public class ProductIndex: ElasticsearchBase
    {
    
            /// <summary>
            /// 柜子编号
            /// </summary>
            public string CabinetCode { get; set; }

            /// <summary>
            /// 柜子名称
            /// </summary>
            public string CabinetName { get; set; }

            /// <summary>
            /// 货品编号
            /// </summary>
            public string ProductCode { get; set; }

            /// <summary>
            /// 货品名称
            /// </summary>
            public string ProductName { get; set; }
            /// <summary>
            /// 供货商编号（供货商MemberName）
            /// </summary>
            public string SupplierCode { get; set; }
            /// <summary>
            /// 分类编号
            /// </summary>
            public string CategoryCode { get; set; }

            /// <summary>
            /// RFID
            /// </summary>
            public string RFID { get; set; }
            /// <summary>
            /// 价格
            /// </summary>
            public decimal Price { get; set; }
            /// <summary>
            /// 有效期
            /// </summary>
            public DateTime TermDate { get; set; }
            /// <summary>
            /// 状态(1上架，2已售，3下架)
            /// </summary>
            public int StatusFlag { get; set; }
            /// <summary>
            /// 上架时间
            /// </summary>
            public DateTime ShelfTime { get; set; }
            /// <DateTime>
            /// 下架时间
            /// </summary>
            public DateTime UnShelfTime { get; set; }

            /// <summary>
            /// 销售时间
            /// </summary>
            public DateTime SaleTime { get; set; }

            /// <summary>
            /// 商品规格
            /// </summary>
            public string Specifications { get; set; }


        

    }
}
