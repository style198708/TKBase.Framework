using System.Collections.Generic;
using TKBase.Framework.MQTT.Adapter;
using TKBase.Framework.MQTT.Diagnostics;

namespace TKBase.Framework.MQTT.Server
{
    public interface IMqttServerFactory
    {
        IMqttServer CreateMqttServer();

        IMqttServer CreateMqttServer(IMqttNetLogger logger);

        IMqttServer CreateMqttServer(IEnumerable<IMqttServerAdapter> adapters, IMqttNetLogger logger);
    }
}