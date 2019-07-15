using System;
using System.Threading.Tasks;
using TKBase.Framework.MQTT.Serializer;

namespace TKBase.Framework.MQTT.Server
{
    public interface IMqttClientSessionStatus
    {
        string ClientId { get; }

        string Endpoint { get; }

        bool IsConnected { get; }

        MqttProtocolVersion? ProtocolVersion { get; }

        TimeSpan LastPacketReceived { get; }

        TimeSpan LastNonKeepAlivePacketReceived { get; }

        int PendingApplicationMessagesCount { get; }

        Task DisconnectAsync();

        Task DeleteSessionAsync();

        Task ClearPendingApplicationMessagesAsync();
    }
}
