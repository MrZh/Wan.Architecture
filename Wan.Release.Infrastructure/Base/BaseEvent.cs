using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wan.Release.Infrastructure.Base
{
    public class BaseEvent
    {
        public string Id { get; protected set; }
        public DateTime CreateTime { get; protected set; }

        public BaseEvent()
        {
            Id = Guid.NewGuid().ToString();
            CreateTime = DateTime.Now;
        }
    }
}
