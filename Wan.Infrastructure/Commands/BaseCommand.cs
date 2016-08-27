using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wan.Infrastructure.Commands
{
    public class BaseCommand<T>
    {
        public string Sql { get; protected set; }

        public T Obj { get; protected set; }

    }
}
