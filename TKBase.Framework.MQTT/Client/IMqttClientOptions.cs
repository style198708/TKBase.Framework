using System;
using TKBase.Framework.MQTT.Serializer;

namespace TKBase.Framework.MQTT.Client
{
    public interface IMqttClientOptions
    {
        string ClientId { get; }
        bool CleanSession { get; }
        IMqttClientCredentials Credentials { get; }
        MqttProtocolVersion ProtocolVersion { get; }
        IMqttClientChannelOptions ChannelOptions { get; }
        
        TimeSpan CommunicationTimeout { get; }
        TimeSpan KeepAlivePeriod { get; }
        TimeSpan? KeepAliveSendInterval { get; }
        
        MqttApplicationMessage WillMessage { get; }
    }
}