using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wan.Release.Infrastructure.Command;

namespace Wan.Release.Infrastructure.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Command<Student> command = new Command<Student>(new Student { Id = Guid.NewGuid().ToString(), Name = "1", Age = "2" });
            CommandBus.SendCommand(command);
            var com =
                Command<Student>.InitBaseCommand(new Student { Id = Guid.NewGuid().ToString(), Name = "1", Age = "2" });
            Console.WriteLine(com.Sql);
        }
    }
}
