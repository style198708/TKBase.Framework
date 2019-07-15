using TKBase.Framework.MQTT.Packets;

namespace TKBase.Framework.MQTT.Server
{
    public class MqttClientSubscribeResult
    {
        public MqttSubAckPacket ResponsePacket { get; set; }

        public bool CloseConnection { get; set; }
    }
}
