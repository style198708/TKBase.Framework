namespace TKBase.Framework.MQTT.Server
{
    public class MqttServerTcpEndpointOptions : MqttServerTcpEndpointBaseOptions
    {
        public MqttServerTcpEndpointOptions()
        {
            IsEnabled = true;
            Port = 1883;
        }
    }
}
