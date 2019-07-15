﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using TKBase.Framework.Redis;
using TKBase.Framework.Middleware;
using TKBase.Framework.WebApi;
using TKBase.Framework.Pay;
using TKBase.Framework.MQTT;

namespace TKBase.Framework.WebSite
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddRedis("Redis.json");
            services.AddWebSocket("mqtt.json");
            services.AddPay("WxSupplierconfig.json");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //var s = WxPayHelp.PayUser("PayUser", new PayUser()
            //{
            //    Amount = 100,
            //    Ip = "192.168.1.1",
            //    OpenId = "o__gS5uxjw-mYsDJRHqgqHZGjlHo",
            //    //OpenId = "opr8T1rg73calMYAg2R5MzQT54xo",
            //    PayOrderCode = "225544",
            //    Remark = "测试"
            //});
            //MqttWebSocketHelp.Publish("topic", "Open");
            //var sddd = WxPayHelp.CreateOrder("CreatePreOrder", new CreatePreOrder()
            //{
            //    OrderAmount = 1,
            //    OrderContent = "消费订单",
            //    OrderCode = "232323",
            //    OpenId = "o__gS5uxjw-mYsDJRHqgqHZGjlHo"
            //});

            //WxPayHelp.CreateOrder("CreatePreOrder", new CreatePreOrder()
            //{
            //    OrderAmount = 1,
            //    OrderContent = "消费订单",
            //    OrderCode = "232323",
            //    OpenId = "opr8T1rg73calMYAg2R5MzQT54xo"
            //});


            //RedisHelper.Set<TicketEntity>("test", new TicketEntity()
            //{
            //    ExpDate = DateTime.Now,
            //    MemberID = 12,
            //    MemberName = "123",
            //    UserKey = Guid.NewGuid(),
            //    VisitorKey = Guid.NewGuid()
            //}, 5 * 60);
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });


        }
    }
}
