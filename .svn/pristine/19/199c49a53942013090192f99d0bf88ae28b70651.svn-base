using TKBase.Framework.MQTT.Protocol;

namespace TKBase.Framework.MQTT.Packets
{
    public class MqttConnAckPacket : MqttBasePacket
    {
        public bool IsSessionPresent { get; set; }

        public MqttConnectReturnCode ConnectReturnCode { get; set; }

        public override string ToString()
        {
            return "ConnAck: [ConnectReturnCode=" + ConnectReturnCode + "] [IsSessionPresent=" + IsSessionPresent + "]";
        }
    }
}
