﻿namespace TKBase.Framework.MQTT.Server
{
    public class PrepareClientSessionResult
    {
        public bool IsExistingSession { get; set; }

        public MqttClientSession Session { get; set; }
    }
}
