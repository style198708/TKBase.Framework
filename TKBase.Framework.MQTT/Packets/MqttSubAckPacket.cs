using System.Collections.Generic;
using System.Linq;
using TKBase.Framework.MQTT.Protocol;

namespace TKBase.Framework.MQTT.Packets
{
    public class MqttSubAckPacket : MqttBasePacket, IMqttPacketWithIdentifier
    {
        public ushort? PacketIdentifier { get; set; }

        public IList<MqttSubscribeReturnCode> SubscribeReturnCodes { get; } = new List<MqttSubscribeReturnCode>();

        public override string ToString()
        {
            var subscribeReturnCodesText = string.Join(",", SubscribeReturnCodes.Select(f => f.ToString()));
            return "SubAck: [PacketIdentifier=" + PacketIdentifier + "] [SubscribeReturnCodes=" + subscribeReturnCodesText + "]";
        }
    }
}
