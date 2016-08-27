using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wan.Infrastructure.Entity;
using Wan.Infrastructure.Extends;

namespace Wan.Infrastructure.Commands
{
    public class DapperCommand<T> : BaseCommand<T> where T : Entity.Entity
    {
        protected List<string> PropsList = null;

        protected string TableName = string.Empty;
        public DapperCommand(T data)
        {
            Obj = data;
            Init(data);
            Sql = GetInsertSql();
        }

        public DapperCommand(T data, CommandEnum typEnum)
        {
            this.Obj = data;
            Init(data);
            Sql = GetInsertSql();
            if (typEnum.Equals(CommandEnum.Update))
            {
                Sql = GetUpdateSql();
            }

            if (typEnum.Equals(CommandEnum.Delete))
            {
                Sql = GetDeleteSql();
            }

        }

        private void Init(T data)
        {

            //ColumnList = new List<string>();
            PropsList = new List<string>();
            Type type = typeof(T);
            TableName = type.GetTableName();
            PropertyInfo[] ps = type.GetProperties();
            if (data == null)
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
                var temp = i.GetValue(data);
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
        /// Insert
        /// </summary>
        /// <returns></returns>
        private string GetInsertSql()
        {
            if (PropsList == null)
            {
                return null;
            }
            String sqlText = "insert into " + TableName + "(";
            String valueText = " values ( ";
            foreach (string props in PropsList)
            {
                sqlText += props + ",";
                valueText += "@" + props + ",";
            }

            sqlText = sqlText.Substring(0, sqlText.Length - 1);
            valueText = valueText.Substring(0, valueText.Length - 1);
            sqlText += ")";
            valueText += ")";

            return sqlText + valueText;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <returns></returns>
        private string GetUpdateSql()
        {
            String sqlText = "update " + TableName + " set ";
            for (int i = 1; i < PropsList.Count; i++)
            {
                sqlText = sqlText + PropsList[i] + "=@" + PropsList[i] + ",";
            }

            sqlText = sqlText.Substring(0, sqlText.Length - 1);
            sqlText += " where " + PropsList[0] + "=@" + PropsList[0];

            return sqlText;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <returns></returns>
        private string GetDeleteSql()
        {
            String sqlText = "delete from " + TableName;
            sqlText += " where " + PropsList[0] + "=@" + PropsList[0];

            return sqlText;
        }

    }
}
