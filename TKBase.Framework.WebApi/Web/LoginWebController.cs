﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TKBase.Framework.Serializer;

namespace TKBase.Framework.WebApi
{
    /// <summary>
    /// Web强制登录
    /// </summary>
    public class LoginWebController : BaseController
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            Ip = GetHostAddress();
            bool a = context.HttpContext.Request.Cookies.ContainsKey("AccessToken");
            bool b = context.HttpContext.Request.Cookies.TryGetValue("AccessToken", out string token);
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
