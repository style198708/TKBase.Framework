using TKBase.Framework.MQTT.Diagnostics;

namespace TKBase.Framework.MQTT.Client
{
    public interface IMqttClientFactory
    {
        IMqttClient CreateMqttClient();

        IMqttClient CreateMqttClient(IMqttNetLogger logger);

        IMqttClient CreateMqttClient(IMqttClientAdapterFactory adapterFactory);

        IMqttClient CreateMqttClient(IMqttNetLogger logger, IMqttClientAdapterFactory adapterFactory);
    }
}