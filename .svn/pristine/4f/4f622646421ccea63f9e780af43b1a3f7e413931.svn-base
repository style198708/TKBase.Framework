using System;

namespace TKBase.Framework.MQTT.Server
{
    public class MqttClientConnectedEventArgs : EventArgs
    {
        public MqttClientConnectedEventArgs(string clientId)
        {
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
        }

        public string ClientId { get; }
    }
}
