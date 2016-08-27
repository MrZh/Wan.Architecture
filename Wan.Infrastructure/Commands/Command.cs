using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wan.Infrastructure.Extends;

namespace Wan.Infrastructure.Commands
{
    public abstract class Command<T>
    {
        public string Id { get; protected set; }

        protected List<string> PropsList = null;

        protected string TableName = string.Empty;

        protected T CommandType = default(T);

        protected Command()
        {
            this.Id = Guid.NewGuid().ToString();
            Init();
        }

        protected Command(T commandType)
        {
            this.Id = Guid.NewGuid().ToString();
            this.CommandType = commandType;
            Init();
        }

        public void Init()
        {

            //ColumnList = new List<string>();
            PropsList = new List<string>();
            Type type = typeof(T);
            TableName = type.GetTableName();
            System.Reflection.PropertyInfo[] ps = type.GetProperties();
            if (CommandType == null)
            {
                foreach (PropertyInfo i in ps)
                {
                    bool isKey = i.IsPrimaryKey();
                    if (isKey)
                    {
                        PropsList.Insert(0, i.Name);
                    }
                    else
                    {
                        PropsList.Add(i.Name);
                    }

                }

                return;
            }
            foreach (PropertyInfo i in ps)
            {
                var temp = i.GetValue(CommandType);
                if (temp != null)
                {
                    bool isKey = i.IsPrimaryKey();
                    if (isKey)
                    {
                        PropsList.Insert(0, i.Name);
                    }

                    else
                    {
                        PropsList.Add(i.Name);
                    }
                }
            }
        }

        /// <summary>
        /// 发送command
        /// </summary>
        public abstract void SendCommand();

        /// <summary>
        /// 发送command
        /// </summary>
        /// <param name="commandType">实体</param>
        public abstract void SendCommand(T commandType);

        /// <summary>
        /// 发送command
        /// </summary>
        /// <param name="type">类型</param>
        public abstract void SendCommand(CommandEnum type);

        /// <summary>
        /// 发送command
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="commandType">实体</param>
        public abstract void SendCommand(CommandEnum type, T commandType);

        /// <summary>
        /// 持久化command
        /// </summary>
        public virtual void StoredCommand()
        {
            //donothing
        }
    }
}
