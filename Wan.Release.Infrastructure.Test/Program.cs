using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wan.Release.Infrastructure.Base;
using Wan.Release.Infrastructure.Command;

namespace Wan.Release.Infrastructure.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student stu = new Student();
            //stu.Age = "2";
            //stu.Name = "3";
            //string temp = stu.GetType().GetQuerySql(stu, QueryEnum.In);
            List<object> list = new List<object>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Student { Id = Guid.NewGuid().ToString(), Age = i.ToString(), Name = Guid.NewGuid().ToString(), CreateTime = DateTime.Now });

            }
           // BaseCommand command=new BaseCommand();
            BaseCommand command = new BaseCommand("sss", list);
            //Command<Student> command = new Command<Student>(new Student { Id = Guid.NewGuid().ToString(), Name = "1", Age = "2" });
            // CommonCommand command = new CommonCommand(list);

            var com = CommonCommand.InitBaseCommands(list);

            CommandBus.SendCommands(com);
            foreach (var item in list)
            {
                Student stu = (Student)item;
                stu.Age = "100";
            }
            list.Remove(list[0]);
            var coms = CommonCommand.InitBaseCommands(list, CommandEnum.Delete);
            CommandBus.SendCommands(coms);
            //Console.WriteLine(com.Sql);
        }
    }
}
