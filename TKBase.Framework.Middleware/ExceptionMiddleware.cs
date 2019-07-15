using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace TKBase.Framework.Middleware
{
    /// <summary>
    /// 异常日志中间件
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var statusCode = context.Response.StatusCode;
                if (ex is ArgumentException)
                {
                    statusCode = 200;
                }
                await HandleExceptionAsync(context, statusCode, ex.Message);
            }
            finally
            {
                var statusCode = context.Response.StatusCode;
                var msg = "";
                if (statusCode == 401)
                {
                    msg = "未授权";
                }
                
                else if (statusCode == 502)
                {
                    msg = "请求错误";
                }
                else if (statusCode != 200)
                {
                    msg = "未知错误";
                }
                if (!string.IsNullOrWhiteSpace(msg))
                {
                    await HandleExceptionAsync(context, statusCode, msg);
                }
            }
        }
        private  Task HandleExceptionAsync(HttpContext context, int statusCode, string msg)
        {
            var data = new { code = statusCode.ToString(), is_success = false, msg = msg };
            var result = TKBase.Framework.Serializer.SerializerJson.SerializeObject(new { data = data });
            try
            {
                //特别说明ContentType属性在 HttpResponse初始化完成之后就不能修改了
                //如果试图修改则抛出异常
                //异常内容：Headers are read-only, response has already started.
                //context.Response.ContentType = "application/json;charset=utf-8";

                //特别说明对于准备输出的Response,执行Clear()清空抛出异常
                //The response cannot be cleared, it has already started sending.
                

                //判断输出流是否已经开始
                //context.Response.HasStarted
            }
            catch (Exception ex)
            {
                //Log.Error(ex);
            }
            //清楚已经完成的相应内容

            return context.Response.WriteAsync(result);
        }
    }
}
