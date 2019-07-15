using System;

namespace TKBase.Framework.MQTT.Diagnostics
{
    public interface IMqttNetLogger
    {
        event EventHandler<MqttNetLogMessagePublishedEventArgs> LogMessagePublished;

        IMqttNetChildLogger CreateChildLogger(string source = null);

        void Publish(MqttNetLogLevel logLevel, string source, string message, object[] parameters, Exception exception);
    }
}
