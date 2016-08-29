using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.CommandId = Guid.NewGuid().ToString();
            this.Sql = obj.GetType().GetSql(obj, commandEnum);
            this.Obj = obj;
        }

        public CommonCommand(List<object> objs,CommandEnum commandEnum)
        {
            if (objs == null) throw new ArgumentNullException(nameof(objs));
            this.CommandId = Guid.NewGuid().ToString();
            if (objs.Count<=0)
            {
                return;
            }

            this.Obj = objs;
            this.Sql = objs[0].GetType().GetSql(objs[0],commandEnum);
        }

        public CommonCommand(List<object> objs)
        {
            if (objs == null) throw new ArgumentNullException(nameof(objs));
            this.CommandId = Guid.NewGuid().ToString();
            if (objs.Count <= 0)
            {
                return;
            }

            this.Obj = objs;
            this.Sql = objs[0].GetType().GetSql(objs[0]);
        }

        public CommonCommand(object obj)
        {
            this.CommandId = Guid.NewGuid().ToString();
            this.Sql = obj.GetType().GetSql(obj);
            this.Obj = obj;
        }

        public CommonCommand(object obj, bool justSql = true, CommandEnum commandEnum = CommandEnum.Insert)
        {
            if (justSql)
            {
                this.Obj = null;
                this.Sql = obj.GetType().GetSql(commandEnum);
            }

            else
            {
                this.Obj = obj;
                this.Sql = obj.GetType().GetSql(obj, commandEnum);
            }

            this.CommandId = Guid.NewGuid().ToString();
        }

        public CommonCommand(List<object> objs, bool justSql = true, CommandEnum commandEnum = CommandEnum.Insert)
        {
            if (justSql)
            {
                this.Obj = null;
                this.Sql = objs[0].GetType().GetSql(commandEnum);
            }

            else
            {
                this.Obj = objs;
                this.Sql = objs[0].GetType().GetSql(objs[0], commandEnum);
            }

            this.CommandId = Guid.NewGuid().ToString();
        }
    }
}
