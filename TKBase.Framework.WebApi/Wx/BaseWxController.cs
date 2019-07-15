using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;


namespace TKBase.Framework.WebApi
{
    /// <summary>
    /// WebCookie验证
    /// </summary>
    public class BaseWxController : BaseController
    {

        public string OpenId { get; set; }

        public string CabinetCode { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            this.Ip = GetHostAddress();
            bool a = context.HttpContext.Request.Cookies.ContainsKey("AccessToken");
            string cb = string.Empty;
            bool b = context.HttpContext.Request.Cookies.TryGetValue("AccessToken", out string token);
            bool c = context.HttpContext.Request.Cookies.TryGetValue("CabinetCode", out cb);
            CabinetCode = cb;
            if (b)
            {
                this.OpenId = token;
            }
            else
            {
                OpenId = "";
            }
          
        }
    }
}
