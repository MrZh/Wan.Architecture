using System;
using System.Collections.Generic;
using Wan.Release.Infrastructure.Base;
using Wan.Release.Infrastructure.Command;
using Wan.Release.Infrastructure.Extends;
using Wan.Release.Infrastructure.Query;

namespace Wan.Release.Infrastructure.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu = new Student();
            stu.Age = "2";
            stu.Name = "3";
            string temp = typeof(Student).GetPrimaryQuerySql(QueryEnum.Equal);

            //BaseQuery bq = Query<Student>.InitPrimaryQuery(new { Id = new string[] { "2f01c01f-f2a7-45dc-af35-71029a7ab003", "3ccaba3a-fbcf-4e5c-83b6-6f0738ff63bd" } });
            //BaseQuery bq = Query<Student>.InitPrimaryQuery(new { Id = new string[] { "2f01c01f-f2a7-45dc-af35-71029a7ab003", "3ccaba3a-fbcf-4e5c-83b6-6f0738ff63bd" } }, QueryEnum.In);
            BaseQuery bq = Query<Student>.InitQuery(new Student {Age = "0",Name = "993755d8-3951-46b7-ade8-5f4dbadf7342" });

            List<Student> student = QueryContext.BaseGetListByParam<Student>(bq);
            // List<object> list = new List<object>();
            // for (int i = 0; i < 10; i++)
            // {
            //     list.Add(new Student { Id = Guid.NewGuid().ToString(), Age = i.ToString(), Name = Guid.NewGuid().ToString(), CreateTime = DateTime.Now });

            // }
            //// BaseCommand command=new BaseCommand();
            // BaseCommand command = new BaseCommand("sss", list);
            // //Command<Student> command = new Command<Student>(new Student { Id = Guid.NewGuid().ToString(), Name = "1", Age = "2" });
            // // CommonCommand command = new CommonCommand(list);

            // var com = CommonCommand.InitBaseCommands(list);

            // CommandBus.SendCommands(com);
            // foreach (var item in list)
            // {
            //     Student stu = (Student)item;
            //     stu.Age = "100";
            // }
            // list.Remove(list[0]);
            // var coms = CommonCommand.InitBaseCommands(list, CommandEnum.Delete);
            // CommandBus.SendCommands(coms);
            //Console.WriteLine(com.Sql);
        }
    }
}
