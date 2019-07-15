﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TKBase.Framework.Dapper;
using TKBase.Framework.EMay;
using System.Xml;
using System.Xml.Linq;
using TKBase.Framework.RestSharp;
using TKBase.Framework.Helper;
using TKBase.Framework.Dapper.Lambda;
using System.Text;
using System.Reflection;
using TKBase.Framework.RabbitMQ;
using TKBase.Framework.Cabinet;
using TKBase.Framework.Configuration;
using TKBase.Framework.Camera;
using TKBase.Framework.MQTT.Client;
using TKBase.Framework.MQTT;
using TKBase.Framework.MQTT.Protocol;
using TKBase.Framework.Elasticsearch;
using TKBase.Framework.Thrift.Transport;
using TKBase.Framework.Thrift.Protocol;
using TKBase.Framework.Thrift.Server;
using TKBase.Framework.Thrift.EventHandler;
using TKBase.Framework.WeiXin;
using TKBase.Framework.WeiXin.Config;
using Nest;
using TKBase.Framework.Scheduler.Log;
using TKBase.Framework.Thrift.Config;
using TKBase.Framework.Thrift;
using XCKJ.RPC.Pay.Contracts;

namespace TKBase.Framework.WebSite
{
    public class User
    {
        public string UserName { get; set; }

        public int Age { get; set; }
    }

    public class TUser
    {
        public string UserName { get; set; }

        public int Age { get; set; }
    }


    public class Program
    {
        public static F Map<T, F>(T entity) where F : new()
        {
            F model = new F();
            var type = model.GetType();
            foreach (PropertyInfo p in type.GetProperties())
            {
                try
                {
                    p.SetValue(model, entity.GetType().GetProperty(p.Name).GetValue(entity));
                }
                catch
                {
                    continue;
                }
            }
            return model;
        }



        // public static IMqttClient mqttClient = new MqttFactory().CreateMqttClient();
        public static void Main(string[] args)
        {

            User u = new User()
            {
                UserName = "张能杰",
                Age = 14
            };

            TUser user = Map<User, TUser>(u);

            ServerConfig payconfig = Config.Bind<ServerConfig>("thrift.json", "Pay");

            //string s = Redis.RedisHelper.Get("2A6B5EDF418F2046DE43F79E0CCE6773");

            // string temp = xElement.ToString();
            //int id = 0;
            //TServerSocket serverTransport = new TServerSocket(8090);

            //TBinaryProtocol.Factory factory = new TBinaryProtocol.Factory();

            //TServerEventHandler handler = new ServerEventHandler();



            //TServer server = new TThreadPoolServer(entity, serverTransport, new TTransportFactory(), factory);
            //server.setEventHandler(handler);

            //Console.WriteLine(string.Format("服务端正在监听{0}端口", serverPort));

            //server.Serve();


            //var response = client.Index(tweet, idx => idx.Index("mytweetindex"));
            //ElasticsearchHelper.Add(tweet);


            Tweet tweet = new Tweet
            {
                Id = 33333,
                User = "kimchy44444",
                Message = "Trying out NEST, so far so good?"
            };
            //ElasticsearchHelper.Add(tweet);

            // Tweet product33 = ElasticsearchHelper.GetByID<Tweet>(33333);

            var response = ElasticsearchHelper.Query<ELog>(fs => fs.From(0).Size(100).Query(q =>
                          q.Bool(b => b.Filter(f => f.TermRange(r => r.Field(t => t.ExecTime).LessThan("2019-03-22")))))
                     );


            SearchRequest s = new SearchRequest()
            {
                From = 0,
                Size = 100,
                Query = new BoolQuery()
                {
                    Filter = new List<QueryContainer>() {
                       new TermRangeQuery() { Field= "ExecTime",LessThan="2019-03-22" }
                    }
                }

            };
            var response3 = ElasticsearchHelper.Query<ELog>(s);
            //product33.User = "43434343434";

            //ElasticsearchHelper.Update<Tweet>(product33);


            ProductIndex product = ElasticsearchHelper.GetByID<ProductIndex>(324);

            //var options = new MqttClientOptions
            //{
            //    ChannelOptions = new MqttClientWebSocketOptions()
            //    {
            //        Uri = "ws://jenkins.miaogo.com.cn:8083/mqtt",
            //        TlsOptions = new MqttClientTlsOptions
            //        {
            //            UseTls = false,
            //            IgnoreCertificateChainErrors = true,
            //            IgnoreCertificateRevocationErrors = true,
            //            AllowUntrustedCertificates = false
            //        }
            //    }
            //};
            //options.CleanSession = true;
            //options.KeepAlivePeriod = TimeSpan.FromSeconds(double.Parse("60"));

            //mqttClient.Connected += MqttClient_Connected;
            //mqttClient.Disconnected += MqttClient_Disconnected;
            //mqttClient.ApplicationMessageReceived += MqttClient_ApplicationMessageReceived;

            //MqttClientConnectResult result = mqttClient.ConnectAsync(options).Result;

            //MqttApplicationMessage appMsg = new MqttApplicationMessage()
            //{
            //    Topic = "testtopic",
            //    Payload = Encoding.UTF8.GetBytes("Hello, World!"),
            //    QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,
            //    Retain = false
            //};

            //Task task = MqttHelp<MqttClientTcpOptions>.Subscribe<Test>("topic1", t =>
            //{
            //    int i = t.Type;
            //});

            //Task tasks = MqttHelp<MqttClientTcpOptions>.Publish<Test>("topic1", new Test() { Type = 3232323 });

            //System.Console.ReadLine();
            //MqttClientOptions options = new MqttClientOptions
            //{
            //    ChannelOptions = new MqttClientTcpOptions()
            //    {
            //        Server = "192.168.3.166",
            //        Port = 1883,
            //    },
            //    KeepAlivePeriod = TimeSpan.FromSeconds(double.Parse("100")),
            //    ClientId = "zbl",
            //    CleanSession = true
            //};
            //mqttClient = new MqttFactory().CreateMqttClient();

            //MqttClientConnectResult result = mqttClient.ConnectAsync(options).Result;

            //mqttClient.ApplicationMessageReceived += MqttClient_ApplicationMessageReceived; ;
            //mqttClient.Connected += MqttClient_Connected;
            //mqttClient.Disconnected += MqttClient_Disconnected;

            //var s = mqttClient.SubscribeAsync(new List<TopicFilter> { new TopicFilter("bzs", MqttQualityOfServiceLevel.AtMostOnce) }).Result;


            //MqttApplicationMessage appMsg = new MqttApplicationMessage()
            //{
            //    Topic = "bzs",
            //    Payload = Encoding.UTF8.GetBytes("Hello, World!"),
            //    QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,
            //    Retain = false
            //};

            //var r = mqttClient.PublishAsync(appMsg);

            //"", Encoding.UTF8.GetBytes("消息内容"), MqttQualityOfServiceLevel.AtMostOnce, false

            //var list = DP.Create<ProductShelfRecord>().ToList().AsList();

            //RabbitMQService.QueueDelete("1030150513141879784");
            //long total = 0;
            //var sddd = DP.GetPage<Product>(1, 15, out total, "SELECT SaleTime ,SUM(Price) as Price from (SELECT date_format(SaleTime,'%Y-%m-%d') as SaleTime , Price ,SupplierCode from Product where StatusFlag=3 and DeleteFlag=0 and  SupplierCode='1040723159508193280' ) as T_Product GROUP BY SaleTime");


            //string url = "https://api.weixin.qq.com/sns/oauth2/access_token";
            //access_token token = new access_token()
            //{
            //    appid = WxConfig.appid,
            //    secret = WxConfig.secret,
            //    code = "021tasN40IlceK1UbAL40FBiN40tasNN",
            //};

            //RestClient client = new RestClient(url);
            //IRestRequest request = new RestRequest(Method.GET);
            //request.AddParameter("appid", token.appid);
            //request.AddParameter("secret", token.secret);
            //request.AddParameter("code", token.code);
            //request.AddParameter("grant_type", token.grant_type);
            ////
            //IRestResponse<access_tokenresult> response = client.Execute<access_tokenresult>(request);



            //int count = DP.DeleteEntity<RelationProductCategory>(p => p.Type == 2 && p.Code == "00001");

            //string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";

            //XDocument document = new XDocument();

            //XElement root = new XElement("xml");

            //root.Add(new XElement("appid", 1));
            //root.Add(new XElement("mch_id", 1));
            //root.Add(new XElement("device_info", 1));
            //root.Add(new XElement("nonce_str", 1));
            //root.Add(new XElement("sign_type", 1));
            //root.Add(new XElement("body", 1));
            //root.Add(new XElement("attach", 1));
            //root.Add(new XElement("out_trade_no", 1));
            //root.Add(new XElement("fee_type", 1));
            //root.Add(new XElement("total_fee", 1));
            //root.Add(new XElement("spbill_create_ip", 1));
            //root.Add(new XElement("time_start", 1));
            //root.Add(new XElement("time_expire", 1));
            //root.Add(new XElement("goods_tag", 1));
            //root.Add(new XElement("notify_url", 1));
            //root.Add(new XElement("trade_type", 1));
            //root.Add(new XElement("limit_pay", 1));
            //root.Add(new XElement("scene_info", 1));
            //document.Add(root);
            //string xml = document.ToString();

            //byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);

            //System.Net.HttpWebResponse response = null;

            //byte[] type = HttpHelper.SendRequestData(url, data, ref response);

            //string t = System.Text.Encoding.UTF8.GetString(type);

            //CabinetHelp.SendMessage(101, new Cabinet.Entity.CabinetParam()
            //{
            //    Queue = "1043041192733970432",
            //    Message= "你好",
            //    Action = new List<object>() { "msg"}

            //});

            //RabbitMQService.Send("1043041192733970432", "33333");
            //RabbitMQService.Send("1043041192733970432", "33444");
            //RabbitMQService.Send("1043041192733970432", "5555");



            //ProductShelfItem shelfItem = new ProductShelfItem()
            //{
            //    ShelfCode = "3333",
            //    ShelfType = 1,
            //    ProductName = "",
            //    Price = 0,
            //    ProCount = 2,
            //    CategoryCode = "",
            //    RFIDs = "121212",
            //    ICO = "",
            //    ProductCode = "",
            //    Specifications = ""
            //};
            //transaction.AddTs(shelfItem);
            //string msg = string.Empty;

            //int f = DP.SaveEntity(shelfItem);
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("hosting.json", optional: true)
            //    .Build();

            //var host = new WebHostBuilder()
            //    .UseConfiguration(config)
            //    .UseKestrel()
            //    .UseStartup<Startup>()
            //    .Build();
            //host.Run();


            //Config.Bind<CameraConfig>("Camera.json");

            ////CameraHelp help = new CameraHelp();

            //var result = CameraHelp.Start("C70425683");





        }


    }


}
