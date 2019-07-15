﻿using System;
using System.Xml.Linq;
using TKBase.Framework.Extension;

namespace TKBase.Framework.Pay
{
    public class AppPayHelp : PayBase
    {
        /// <summary>
        /// 创建统一支付订单
        /// </summary>
        /// <param name="Api"></param>
        /// <param name="order"></param>
        public static XElement CreateOrder(string Api, CreatePreOrder entity)
        {
            XElement ele = GetApi(Api);
            ele.AddElementValue("device_info", "A123");
            ele.AddElementValue("fee_type", "CNY");
            ele.AddElementValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
            ele.AddElementValue("notify_url", entity.NotifyUrl);
            ele.AddElementValue("trade_type", "APP");
            ele.AddElementValue("openid", entity.OpenId);
            ele.AddElementValue("spbill_create_ip", entity.Ip);
            ele.AddElementValue("body", entity.OrderContent);
            ele.AddElementValue("detail", entity.OrderContent);
            ele.AddElementValue("total_fee", Convert.ToInt32(entity.OrderAmount * 100));
            ele.AddElementValue("out_trade_no", entity.OrderCode);
            ele.AddElementValue("attach", entity.Attach);
            GetBaseParam(ref ele, ele.Attribute("BaseParam").Value, AppConfig.AppId, AppConfig.MchId,AppConfig.Key);
            XDocument document = new XDocument();
            XElement xElement = new XElement("xml");
            foreach (XElement ch in ele.Elements())
            {
                if (!string.IsNullOrEmpty(ch.Value))
                    xElement.Add(new XElement(ch.Name, new XCData(ch.Value)));
            }
            return Post(ele.Attribute("url").Value, xElement,AppConfig.WxUrl);
        }

        /// <summary>
        /// 查询订单号
        /// </summary>
        /// <param name="Api"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static XElement SearchOrder(string Api, SeachOrder entity)
        {
            XElement ele = GetApi(Api);
            ele.AddElementValue("out_trade_no", entity.OrderCode);

            GetBaseParam(ref ele, ele.Attribute("BaseParam").Value, AppConfig.AppId, AppConfig.MchId,AppConfig.Key);
            XDocument document = new XDocument();
            XElement xElement = new XElement("xml");
            foreach (XElement ch in ele.Elements())
            {
                xElement.Add(new XElement(ch.Name, new XCData(ch.Value)));
            }
            return Post(ele.Attribute("url").Value, xElement, AppConfig.WxUrl);

        }





    }
}
