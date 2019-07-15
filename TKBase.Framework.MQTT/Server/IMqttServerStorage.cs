using System.Collections.Generic;
using System.Threading.Tasks;

namespace TKBase.Framework.MQTT.Server
{
    public interface IMqttServerStorage
    {
        Task SaveRetainedMessagesAsync(IList<MqttApplicationMessage> messages);

        Task<IList<MqttApplicationMessage>> LoadRetainedMessagesAsync();
    }
}
