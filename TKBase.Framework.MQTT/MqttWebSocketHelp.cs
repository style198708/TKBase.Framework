using System;
using System.Collections.Generic;
using System.Text;
using TKBase.Framework.MQTT.Client;
using TKBase.Framework.MQTT.Protocol;

namespace TKBase.Framework.MQTT
{
    public class MqttWebSocketHelp
    {
        public static IMqttClient mqttClient;

        static MqttWebSocketHelp()
        {
            if (mqttClient == null)
                mqttClient = new MqttFactory().CreateMqttClient();

            if (!mqttClient.IsConnected)
            {
                Connect();
            }
        }

        private static void Connect()
        {
            MqttClientOptions options = new MqttClientOptions
            {
                ChannelOptions = new MqttClientWebSocketOptions()
                {
                    Uri = WebSocketConfig.Uri,
                    TlsOptions = new MqttClientTlsOptions
                    {
                        UseTls = false,
                        IgnoreCertificateChainErrors = true,
                        IgnoreCertificateRevocationErrors = true,
                        AllowUntrustedCertificates = false
                    }
                }
            };
            options.CleanSession = true;
            options.KeepAlivePeriod = TimeSpan.FromSeconds(WebSocketConfig.KeepAlivePeriod);
            var task = mqttClient.ConnectAsync(options).Result;
        }

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="Topic"></param>
        /// <param name="Messsage"></param>
        /// <returns></returns>
        public static async void Publish(string Topic, string Messsage)
        {
            MqttApplicationMessage appMsg = new MqttApplicationMessage()
            {
                Topic = Topic,
                Payload = Encoding.UTF8.GetBytes(Messsage),
                QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,
                Retain = false

            };
           
            if (!mqttClient.IsConnected)
                Connect();
            await mqttClient.PublishAsync(appMsg);
        }

        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="Topic"></param>
        public static async void Subscribe(string Topic)
        {
            if (!mqttClient.IsConnected)
                Connect();
            await mqttClient.SubscribeAsync(new List<TopicFilter> { new TopicFilter(Topic, MqttQualityOfServiceLevel.AtMostOnce) });
        }
    }
}
