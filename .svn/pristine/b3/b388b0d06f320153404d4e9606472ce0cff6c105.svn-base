using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TKBase.Framework.Serializer;

namespace TKBase.Framework.WebApi
{
    public class LoginWxController:BaseController
    {
        public string OpenId { get; set; }

        public string CabinetCode { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            this.Ip = GetHostAddress();
            bool a = context.HttpContext.Request.Cookies.ContainsKey("AccessToken");
            bool b = context.HttpContext.Request.Cookies.TryGetValue("AccessToken", out string token);
            string cb = string.Empty; ;
            bool c = context.HttpContext.Request.Cookies.TryGetValue("CabinetCode", out cb);
            CabinetCode = cb;
            if (b)
            {
                this.OpenId = token;
            }
            else
            {
                context.Result = new ContentResult()
                {
                    Content = SerializerJson.SerializeObject(new
                    {
                        code = 30,
                        msg = "请重新登录",
                    }),
                    StatusCode = 200
                };
            } 
        }
    }
}
