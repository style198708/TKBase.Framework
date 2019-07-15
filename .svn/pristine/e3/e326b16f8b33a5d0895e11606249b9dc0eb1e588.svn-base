using System;
using System.Threading;
using System.Threading.Tasks;
using TKBase.Framework.MQTT.Packets;
using TKBase.Framework.MQTT.Serializer;

namespace TKBase.Framework.MQTT.Adapter
{
    public interface IMqttChannelAdapter : IDisposable
    {
        string Endpoint { get; }

        IMqttPacketSerializer PacketSerializer { get; }

        event EventHandler ReadingPacketStarted;

        event EventHandler ReadingPacketCompleted;

        Task ConnectAsync(TimeSpan timeout, CancellationToken cancellationToken);

        Task DisconnectAsync(TimeSpan timeout, CancellationToken cancellationToken);

        Task SendPacketAsync(MqttBasePacket packet, CancellationToken cancellationToken);

        Task<MqttBasePacket> ReceivePacketAsync(TimeSpan timeout, CancellationToken cancellationToken);
    }
}
