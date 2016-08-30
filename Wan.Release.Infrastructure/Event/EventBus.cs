using System.Threading.Tasks;
using Wan.Release.Infrastructure.Base;

namespace Wan.Release.Infrastructure.Event
{
    public class EventBus
    {
        public static void SendEvent(BaseEvent envent)
        {
            Task.Run(() => envent.SentEvent());
        }
    }
}
