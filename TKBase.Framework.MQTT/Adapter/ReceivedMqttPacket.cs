using TKBase.Framework.MQTT.Serializer;

namespace TKBase.Framework.MQTT.Adapter
{
    public class ReceivedMqttPacket
    {
        public ReceivedMqttPacket(byte fixedHeader, MqttPacketBodyReader body)
        {
            FixedHeader = fixedHeader;
            Body = body;
        }

        public byte FixedHeader { get; }

        public MqttPacketBodyReader Body { get; }
    }
}
