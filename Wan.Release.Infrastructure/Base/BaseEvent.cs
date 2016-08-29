using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Wan.Release.Infrastructure.Base
{
    public class BaseEvent
    {
        public string Id { get; protected set; }
        public DateTime CreateTime { get; protected set; }

        public string EventBody { get; protected set; }

        public string Author { get; protected set; }

        public BaseEvent(BaseCommand command, string author = null)
        {
            Author = author;
            EventBody = JsonConvert.SerializeObject(command);
            Id = Guid.NewGuid().ToString();
            CreateTime = DateTime.Now;
        }

        public BaseEvent(List<BaseCommand> command, string author = null)
        {
            Author = author;
            EventBody = JsonConvert.SerializeObject(command);
            Id = Guid.NewGuid().ToString();
            CreateTime = DateTime.Now;
        }

        public virtual void SentEvent()
        {
            //do
        }
    }
}
