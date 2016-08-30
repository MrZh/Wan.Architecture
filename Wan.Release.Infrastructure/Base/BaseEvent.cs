using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Wan.Release.Infrastructure.Base
{
    public abstract class BaseEvent
    {
        public string Id { get; protected set; }
        public DateTime CreateTime { get; protected set; }

        public string EventBody { get; protected set; }

        public string Author { get; protected set; }

        protected BaseEvent(BaseCommand command, string author = null)
        {
            Author = author;
            EventBody = JsonConvert.SerializeObject(command);
            Id = Guid.NewGuid().ToString();
            CreateTime = DateTime.Now;
        }

        protected BaseEvent(List<BaseCommand> command, string author = null)
        {
            Author = author;
            EventBody = JsonConvert.SerializeObject(command);
            Id = Guid.NewGuid().ToString();
            CreateTime = DateTime.Now;
        }

        public abstract void SentEvent();
    }
}
