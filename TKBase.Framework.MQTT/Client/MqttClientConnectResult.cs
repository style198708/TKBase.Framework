﻿namespace TKBase.Framework.MQTT.Client
{
    public class MqttClientConnectResult
    {
        public MqttClientConnectResult(bool isSessionPresent)
        {
            IsSessionPresent = isSessionPresent;
        }

        public bool IsSessionPresent { get; }
    }
}
