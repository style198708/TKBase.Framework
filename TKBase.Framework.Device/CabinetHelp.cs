﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using TKBase.Framework.Configuration;
using System.Linq;
using TKBase.Framework.MQTT.Channel;
using TKBase.Framework.Serializer;
using TKBase.Framework.MQTT;
using TKBase.Framework.MQTT.Client;
using System.Threading.Tasks;

namespace TKBase.Framework.Device
{
    public class CabinetHelp
    {
        /// <summary>
        /// 发送指令
        /// </summary>
        /// <param name="Queue"></param>
        /// <param name="ShelfCode"></param>
        /// <returns></returns>
        public static void  SendMessage(string Queue, string Operation, BaseAction ActionData)
        {
            BaseResult cabinet = Config.Bind<BaseResult>("Device.json", Operation);
            ActionData.Msg = string.Format(cabinet.Message, ActionData.Msg);
            cabinet.ActionData = ActionData;
            MqttHelp<MqttClientTcpOptions>.Publish<BaseResult>(Queue, cabinet);
        }   
    }
}
