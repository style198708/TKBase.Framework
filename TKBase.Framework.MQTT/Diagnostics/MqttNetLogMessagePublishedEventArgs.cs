using System;

namespace TKBase.Framework.MQTT.Diagnostics
{
    public class MqttNetLogMessagePublishedEventArgs : EventArgs
    {
        public MqttNetLogMessagePublishedEventArgs(MqttNetLogMessage logMessage)
        {
            TraceMessage = logMessage ?? throw new ArgumentNullException(nameof(logMessage));
        }

        public MqttNetLogMessage TraceMessage { get; }
    }
}
