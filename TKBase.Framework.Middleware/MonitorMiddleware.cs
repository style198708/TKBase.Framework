using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TKBase.Framework.Middleware
{
    /// <summary>
    /// 监控中件间
    /// </summary>
    public class MonitorMiddleware
    {
        private readonly RequestDelegate _next;
    
        public MonitorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);
        }

    }
}
