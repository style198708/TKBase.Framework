using System;
using TKBase.Framework.MQTT.Adapter;
using TKBase.Framework.MQTT.Client;
using TKBase.Framework.MQTT.Diagnostics;
using TKBase.Framework.MQTT.Serializer;

namespace TKBase.Framework.MQTT.Implementations
{
    public class MqttClientAdapterFactory : IMqttClientAdapterFactory
    {
        public IMqttChannelAdapter CreateClientAdapter(IMqttClientOptions options, IMqttNetChildLogger logger)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            var serializer = new MqttPacketSerializer { ProtocolVersion = options.ProtocolVersion };

            switch (options.ChannelOptions)
            {
                case MqttClientTcpOptions _:
                    {
                        return new MqttChannelAdapter(new MqttTcpChannel(options), serializer, logger);
                    }

                case MqttClientWebSocketOptions webSocketOptions:
                    {
                        return new MqttChannelAdapter(new MqttWebSocketChannel(webSocketOptions), serializer, logger);
                    }

                default:
                    {
                        throw new NotSupportedException();
                    }
            }
        }
    }
}
