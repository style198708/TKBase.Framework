﻿using TKBase.Framework.MQTT.Protocol;

namespace TKBase.Framework.MQTT.Packets
{
    public class MqttPublishPacket : MqttBasePublishPacket
    {
        public bool Retain { get; set; }

        public MqttQualityOfServiceLevel QualityOfServiceLevel { get; set; }

        public bool Dup { get; set; }

        public string Topic { get; set; }

        public byte[] Payload { get; set; }

        public override string ToString()
        {
            return "Publish: [Topic=" + Topic + "]" +
                " [Payload.Length=" + Payload?.Length + "]" +
                " [QoSLevel=" + QualityOfServiceLevel + "]" +
                " [Dup=" + Dup + "]" +
                " [Retain=" + Retain + "]" +
                " [PacketIdentifier=" + PacketIdentifier + "]";
        }
    }
}
