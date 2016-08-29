using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wan.Infrastructure.Commands;

namespace Wan.Infrastructure.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student { Id = Guid.NewGuid().ToString(), Name = Guid.NewGuid().ToString() };
            List<object> list = new List<object> {student};
            CommonCommand command=new CommonCommand(list,true,CommandEnum.Insert);
            Console.WriteLine(command.CommandId);
            //Console.WriteLine(command.Obj.GetType());
            Console.WriteLine(command.Sql);
        }
    }
}
