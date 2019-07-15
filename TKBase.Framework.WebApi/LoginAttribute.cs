﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TKBase.Framework.Serializer;

namespace TKBase.Framework.WebApi
{
    /// <summary>
    /// / 针对Action权限验证
    /// </summary>
    public class LoginAttribute : ActionFilterAttribute, IActionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            TicketEntity CurrentUserTicket;

            bool a = context.HttpContext.Request.Headers.ContainsKey("AccessToken");
            bool b = context.HttpContext.Request.Headers.TryGetValue("AccessToken", out Microsoft.Extensions.Primitives.StringValues token);
            if (!string.IsNullOrWhiteSpace(token))
            {
                RedisCacheTicket authBase = new RedisCacheTicket(token);
                TicketEntity userTicket = authBase.CurrUserInfo;
                if (userTicket != null && userTicket.MemberID > 0)
                {
                    CurrentUserTicket = userTicket;
                }
                else
                {
                    //直接输出结果，不经过Controller
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
