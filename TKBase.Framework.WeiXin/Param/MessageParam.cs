using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.WeiXin.Param
{
    /// <summary>
    /// 消息模板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MessageParam<T> where T : class
    {
        public string touser { get; set; }

        public string template_id { get; set; }

        public string url { get; set; }

        public T data { get; set; }
    }

  
   
    /// <summary>
    ///  
    /// </summary>
    public class RechargeTempMessage
    {
        public Key first { get; set; }

        public Key DateTime { get; set; }

        public Key PayAmount { get; set; }

        public Key Location { get; set; }

        public Key remark { get; set; }
    }

    public class Key
    {
        public string value { get; set; }

        public string color { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class RechargeMessage
    {
        /// <summary>
        /// 消息发送人
        /// </summary>
        public string ToOpenId { get; set; }

        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal Money { get; set; } 
    }

}
