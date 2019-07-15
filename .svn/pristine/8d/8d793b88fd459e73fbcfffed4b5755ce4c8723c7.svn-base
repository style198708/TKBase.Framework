using Microsoft.AspNetCore.Mvc.Filters;

namespace TKBase.Framework.WebApi
{
    public class SignAttribute : ActionFilterAttribute, IActionFilter
    {
        public string Key { get; set; }
        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //object obj = context.ActionArguments[Key];
            //bool a = context.HttpContext.Request.Headers.ContainsKey("Sign");
            //Microsoft.Extensions.Primitives.StringValues sign;
            //bool b = context.HttpContext.Request.Headers.TryGetValue("Sign", out sign);
            //if (!string.IsNullOrWhiteSpace(sign))
            //{
            //    SortedDictionary<string, string> pairs = obj.ToSortedDictionary();
            //    if (PaySign.AddSign(pairs, AppConfig.Key) != sign)
            //    {
            //        context.Result = new ContentResult()
            //        {
            //            Content = SerializerJson.SerializeObject(new
            //            {
            //                code = 450,
            //                msg = "签名未通过",
            //            }),
            //            StatusCode = 200
            //        };
            //    }
            //}
            //else
            //{
            //    context.Result = new ContentResult()
            //    {
            //        Content = SerializerJson.SerializeObject(new
            //        {
            //            code = 400,
            //            msg = "签名不能为空",
            //        }),
            //        StatusCode = 200
            //    };
            //}

        }
    }
}
