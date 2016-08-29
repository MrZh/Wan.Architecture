using System;
using System.Collections.Generic;
using Wan.Infrastructure.Extends;

namespace Wan.Infrastructure.Commands
{
    public class CommonCommand
    {

        public string CommandId { get; protected set; }

        public string Sql { get; protected set; }

        public object Obj { get; protected set; }

        public CommonCommand(object obj, CommandEnum commandEnum)
        {
            CommandId = Guid.NewGuid().ToString();
            Sql = obj.GetType().GetSql(obj, commandEnum);
            Obj = obj;
        }

        public CommonCommand(List<object> objs,CommandEnum commandEnum)
        {
            if (objs == null) throw new ArgumentNullException(nameof(objs));
            CommandId = Guid.NewGuid().ToString();
            if (objs.Count<=0)
            {
                return;
            }

            Obj = objs;
            Sql = objs[0].GetType().GetSql(objs[0],commandEnum);
        }

        public CommonCommand(List<object> objs)
        {
            if (objs == null) throw new ArgumentNullException(nameof(objs));
            CommandId = Guid.NewGuid().ToString();
            if (objs.Count <= 0)
            {
                return;
            }

            Obj = objs;
            Sql = objs[0].GetType().GetSql(objs[0]);
        }

        public CommonCommand(object obj)
        {
            CommandId = Guid.NewGuid().ToString();
            Sql = obj.GetType().GetSql(obj);
            Obj = obj;
        }

        public CommonCommand(object obj, bool justSql = true, CommandEnum commandEnum = CommandEnum.Insert)
        {
            if (justSql)
            {
                Obj = null;
                Sql = obj.GetType().GetSql(commandEnum);
            }

            else
            {
                Obj = obj;
                Sql = obj.GetType().GetSql(obj, commandEnum);
            }

            CommandId = Guid.NewGuid().ToString();
        }

        public CommonCommand(List<object> objs, bool justSql = true, CommandEnum commandEnum = CommandEnum.Insert)
        {
            if (justSql)
            {
                Obj = null;
                Sql = objs[0].GetType().GetSql(commandEnum);
            }

            else
            {
                Obj = objs;
                Sql = objs[0].GetType().GetSql(objs[0], commandEnum);
            }

            CommandId = Guid.NewGuid().ToString();
        }
    }
}
