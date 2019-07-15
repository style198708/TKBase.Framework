using System;

namespace TKBase.Framework.MQTT
{
    public interface IApplicationMessageReceiver
    {
        event EventHandler<MqttApplicationMessageReceivedEventArgs> ApplicationMessageReceived;
    }
}
