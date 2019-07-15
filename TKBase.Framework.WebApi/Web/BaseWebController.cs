﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.WebApi
{
    /// <summary>
    /// WebCookie验证
    /// </summary>
    public class BaseWebController:BaseController
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
            }
        }
    }
}

