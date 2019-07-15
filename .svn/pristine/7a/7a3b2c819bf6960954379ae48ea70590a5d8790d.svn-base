using TKBase.Framework.MQTT.Exceptions;
using TKBase.Framework.MQTT.Protocol;

namespace TKBase.Framework.MQTT.Adapter
{
    public class MqttConnectingFailedException : MqttCommunicationException
    {
        public MqttConnectingFailedException(MqttConnectReturnCode returnCode)
            : base($"Connecting with MQTT server failed ({returnCode}).")
        {
            ReturnCode = returnCode;
        }

        public MqttConnectReturnCode ReturnCode { get; }
    }
}
