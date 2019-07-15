using Microsoft.AspNetCore.Builder;

namespace TKBase.Framework.Middleware
{
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// 注册登录验证中间件
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseAuth(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }


        #region 异常处理中间件
        /// <summary>
        /// 注册异常中间件（很少用）
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }

        #endregion

        /// <summary>
        /// 注册监控中间件
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseMonitor(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MonitorMiddleware>();
        }

        #region IServiceCollection

     

    
        #endregion



    }
}
