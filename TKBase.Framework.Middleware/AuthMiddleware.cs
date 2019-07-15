using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TKBase.Framework.Middleware
{

    /// <summary>
    /// 自定义用户验证
    /// </summary>
   public  class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            await _next.Invoke(context);
        }
    }
}
