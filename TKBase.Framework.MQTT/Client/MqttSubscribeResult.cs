using TKBase.Framework.MQTT.Protocol;

namespace TKBase.Framework.MQTT.Client
{
    public class MqttSubscribeResult
    {
        public MqttSubscribeResult(TopicFilter topicFilter, MqttSubscribeReturnCode returnCode)
        {
            TopicFilter = topicFilter;
            ReturnCode = returnCode;
        }

        public TopicFilter TopicFilter { get; }

        public MqttSubscribeReturnCode ReturnCode { get; }
    }
}
