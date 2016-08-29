using System;
using System.Collections.Generic;
using System.Linq;
using Wan.Release.Infrastructure.Base;
using Wan.Release.Infrastructure.Extends;

namespace Wan.Release.Infrastructure.Command
{
    public class CommonCommand : BaseCommand
    {
        public CommonCommand(object obj, CommandEnum commandEnum)
        {
            CommandId = Guid.NewGuid().ToString();
            Sql = obj.GetType().GetSql(obj, commandEnum);
            Obj = obj;
        }

        public CommonCommand(List<object> objs, CommandEnum commandEnum)
        {
            if (objs == null) throw new ArgumentNullException(nameof(objs));
            CommandId = Guid.NewGuid().ToString();
            if (objs.Count <= 0)
            {
                return;
            }

            Obj = objs;
            Sql = objs[0].GetType().GetSql(objs[0], commandEnum);
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

        public static BaseCommand InitBaseCommand(object obj, CommandEnum commandEnum = CommandEnum.Insert)
        {
            return new BaseCommand(obj.GetType().GetSql(commandEnum), obj);
        }

        /// <summary>
        /// 只用于批量增加数据
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="commandEnum"></param>
        /// <returns></returns>
        public static BaseCommand InitBaseCommand(List<object> objs, CommandEnum commandEnum = CommandEnum.Insert)
        {
            if (objs.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(objs));
            return new BaseCommand(objs[0].GetType().GetSql(CommandEnum.Insert), objs);
        }

        public static List<BaseCommand> InitBaseCommands(List<object> objs, CommandEnum commandEnum = CommandEnum.Insert)
        {
            if (objs.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(objs));

            return objs.Select(item => new BaseCommand(item.GetType().GetSql(item, commandEnum), item)).ToList();
        }
    }
}
