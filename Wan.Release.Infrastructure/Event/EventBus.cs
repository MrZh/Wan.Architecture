using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
