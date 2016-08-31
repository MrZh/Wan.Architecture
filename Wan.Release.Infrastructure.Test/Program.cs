using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Wan.Release.Infrastructure.Command;


namespace Wan.Release.Infrastructure.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Student stu = new Student();
            //stu.Age = "2";
            //stu.Name = "3";
            //string temp = typeof(Student).GetPrimaryQuerySql(QueryEnum.Equal);

            //BaseQuery bq = Query<Student>.InitPrimaryQuery(new { Id = new string[] { "2f01c01f-f2a7-45dc-af35-71029a7ab003", "3ccaba3a-fbcf-4e5c-83b6-6f0738ff63bd" } });
            //BaseQuery bq = Query<Student>.InitPrimaryQuery(new { Id = new string[] { "2f01c01f-f2a7-45dc-af35-71029a7ab003", "3ccaba3a-fbcf-4e5c-83b6-6f0738ff63bd" } }, QueryEnum.In);
            //BaseQuery bq = Query<Student>.InitQuery(new Student {Age = "0",Name = "993755d8-3951-46b7-ade8-5f4dbadf7342" });

            //List<Student> student = QueryContext.BaseGetListByParam<Student>(bq);

            //Console.WriteLine(com.Sql);
            List<Student> list = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Student { Id = Guid.NewGuid().ToString(), Age = i.ToString(), Name = Guid.NewGuid().ToString(), CreateTime = DateTime.Now });

            }
            var com = Command<Student>.InitBaseCommands(list);
            Infrastructure.CommandBus.BaseCommandBus.BaseSendCommands(com);
            Console.Read();
        }
    }
}
