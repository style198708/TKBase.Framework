using System;
using System.IO;
using System.Xml.Linq;
using TKBase.Framework.Helper;
using TKBase.Framework.WeiXin.Common;
using TKBase.Framework.WeiXin.Config;
using TKBase.Framework.WeiXin.Entity;
using TKBase.Framework.WeiXin.Param;

namespace TKBase.Framework.WeiXin
{
    public class WPayHelp : PayBase
    {
        /// <summary>
        /// 创建统一支付订单
        /// </summary>
        /// <param name="Api"></param>
        /// <param name="order"></param>
        public static XElement CreateOrder(CreatePreOrder entity)
        {
            CreatePreOrderParam param = new CreatePreOrderParam()
            {
                device_info = "A123",
                fee_type = "CNY",
                time_start = DateTime.Now.ToString("yyyyMMddHHmmss"),
                notify_url = entity.NotifyUrl,
                trade_type = "JSAPI",
                openid = entity.OpenId,
                spbill_create_ip = entity.Ip,
                body = entity.OrderContent,
                total_fee = Convert.ToInt32(entity.OrderAmount * 100).ToString(),
                out_trade_no = entity.OrderCode,
                attach = entity.Attach,
            };
            return Post(Host.CreatePreOrder, param);
        }

        /// <summary>
        /// 查询订单号
        /// </summary>
        /// <param name="Api"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static XElement SearchOrder(SeachOrder entity)
        {
            SearchOrderParam param = new SearchOrderParam()
            {
                out_trade_no = entity.OrderCode
            };
            return Post(Host.SearchOrder, param);
        }

        /// <summary>
        /// 支付中签约
        /// </summary>
        /// <param name="Api"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static XElement ContractOrder(CreatePreOrder entity)
        {
            ContractParam param = new ContractParam()
            {
                out_trade_no = entity.OrderCode,
                device_info = "A123",
                body = entity.OrderContent,
                notify_url = entity.NotifyUrl,
                total_fee = Convert.ToInt32(entity.OrderAmount * 100).ToString(),
                spbill_create_ip = entity.Ip,
                trade_type = "JSAPI",
                openid = entity.OpenId,
                plan_id = "12",
                contract_code = "100001256",
                request_serial = "100001253336",
                contract_display_account = "123",
                contract_notify_url = entity.NotifyUrl,
                attach = entity.Attach
            };
            return Post(Host.PayContract, param);
        }

        /// <summary>
        /// 申请免密支付
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static XElement NoPassCreateOrder(NoPassCreateOrder entity)
        {
            NoPassUserParam param = new NoPassUserParam()
            {
                fee_type = "CNY",
                notify_url = entity.NotifyUrl,
                trade_type = "PAP",
                spbill_create_ip = entity.Ip,
                body = entity.OrderContent,
                total_fee = Convert.ToInt32(entity.OrderAmount * 100).ToString(),
                out_trade_no = entity.OrderCode,
                attach = entity.Attach,
                contract_id = entity.ContractId
            };
            return Post(Host.NoPassUser, param);
        }

        /// <summary>
        /// 付款给用户
        /// </summary>
        /// <param name="Api"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static XElement PayUser(string Api, PayUser entity)
        {
            PayUserParam param = new PayUserParam()
            {
                device_info = "A123",
                partner_trade_no = entity.PayOrderCode,
                openid = entity.OpenId,
                check_name = "NO_CHECK",
                amount = Decimal.ToInt32(entity.Amount * 100).ToString(),
                desc = entity.Remark,
                spbill_create_ip = entity.Ip
            };
            return Post(Host.PayUser, param, new CertificateEntity()
            {
                CFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + JsApiConfig.MchId + ".p12"),
                PassWord = JsApiConfig.MchId
            });
        }
    }
}
