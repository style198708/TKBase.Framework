using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TKBase.Framework.Serializer;

namespace TKBase.Framework.WebApi.Wx
{
    public class LoginWxAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            bool b = context.HttpContext.Request.Cookies.TryGetValue("AccessToken", out string token);
            if (!b)
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
