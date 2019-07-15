using System;
using System.Threading.Tasks;
using TKBase.Framework.MQTT.Server;

namespace TKBase.Framework.MQTT.Adapter
{
    public interface IMqttServerAdapter : IDisposable
    {
        event EventHandler<MqttServerAdapterClientAcceptedEventArgs> ClientAccepted;

        Task StartAsync(IMqttServerOptions options);
        Task StopAsync();
    }
}
