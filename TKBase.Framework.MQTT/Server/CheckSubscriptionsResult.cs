using TKBase.Framework.MQTT.Protocol;

namespace TKBase.Framework.MQTT.Server
{
    public class CheckSubscriptionsResult
    {
        public bool IsSubscribed { get; set; }

        public MqttQualityOfServiceLevel QualityOfServiceLevel { get; set; }
    }
}
