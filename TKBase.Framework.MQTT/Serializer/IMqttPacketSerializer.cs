using System;
using TKBase.Framework.MQTT.Adapter;
using TKBase.Framework.MQTT.Packets;

namespace TKBase.Framework.MQTT.Serializer
{
    public interface IMqttPacketSerializer
    {
        MqttProtocolVersion ProtocolVersion { get; set; }

        ArraySegment<byte> Serialize(MqttBasePacket mqttPacket);

        MqttBasePacket Deserialize(ReceivedMqttPacket receivedMqttPacket);

        void FreeBuffer();
    }
}