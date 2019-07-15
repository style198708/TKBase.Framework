using System;
using System.Threading.Tasks;

namespace TKBase.Framework.MQTT.Adapter
{
    public class MqttServerAdapterClientAcceptedEventArgs : EventArgs
    {
        public MqttServerAdapterClientAcceptedEventArgs(IMqttChannelAdapter client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public IMqttChannelAdapter Client { get; }

        public Task SessionTask { get; set; }
    }
}
