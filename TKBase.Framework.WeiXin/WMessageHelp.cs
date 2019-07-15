using System;
using TKBase.Framework.RestSharp;
using TKBase.Framework.Serializer;
using TKBase.Framework.WeiXin.Common;
using TKBase.Framework.WeiXin.Config;
using TKBase.Framework.WeiXin.Param;

namespace TKBase.Framework.WeiXin
{
    public class WMessageHelp
    {
        /// <summary>
        /// 发送充值消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool SendMessage(RechargeMessage message)
        {
            MessageConfig config = TKBase.Framework.Configuration.Config.Bind<MessageConfig>("Service.json", "RechargeMessage");
            MessageParam<RechargeTempMessage> messageParam = new MessageParam<RechargeTempMessage>()
            {
                touser = message.ToOpenId,
                template_id = config.TemplateId,
                url = config.Url,
                data = new RechargeTempMessage()
                {
                    first = new Key { color = "#173177", value = "恭喜你购买成功" },
                    DateTime = new Key { color = "#173177", value = DateTime.Now.ToString("yyyy年MM月dd日") },
                    PayAmount = new Key { color = "#173177", value = string.Format("{0}元", message.Money) },
                    Location = new Key { color = "#173177", value = "广东深圳" },
                    remark = new Key { color = "#173177", value = "欢迎再次购买!" }
                }
            };
            return SendMessage(messageParam);
        }


        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        private static bool SendMessage<T>(MessageParam<T> param) where T : class
        {
            AccessToken token = WUserHelp.GetAccessToken();
            RestClient client = new RestClient(string.Format("{0}?access_token={1}", Host.Message, token.access_token));
            IRestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(param);
            IRestResponse response = client.Execute(request);
            JsApiBase jsApiBase = SerializerJson.DeserializeObject<JsApiBase>(response.Content); ;
            return jsApiBase.errcode == 0;
        }
    }
}
