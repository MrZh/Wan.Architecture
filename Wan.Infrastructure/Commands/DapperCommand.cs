using System;
using System.Collections.Generic;
using System.Reflection;
using Wan.Infrastructure.Extends;

namespace Wan.Infrastructure.Commands
{
    public class DapperCommand<T> : BaseCommand<T> where T : Entity.Entity
    {
        protected List<string> PropsList;

        protected string TableName = string.Empty;
        public DapperCommand(T data)
        {
            Obj = data;
            Init(data);
            Sql = GetInsertSql();
        }

        public DapperCommand(T data, CommandEnum typEnum)
        {
            Obj = data;
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
            var type = typeof(T);
            TableName = type.GetTableName();
            var ps = type.GetProperties();
            if (data == null)
            {
                foreach (var i in ps)
                {
                    var isKey = i.IsPrimaryKey();
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
            foreach (var i in ps)
            {
                var temp = i.GetValue(data);
                if (temp == null) continue;
                var isKey = i.IsPrimaryKey();
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
            var sqlText = "insert into " + TableName + "(";
            var valueText = " values ( ";
            foreach (var props in PropsList)
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
            var sqlText = "update " + TableName + " set ";
            for (var i = 1; i < PropsList.Count; i++)
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
            var sqlText = "delete from " + TableName;
            sqlText += " where " + PropsList[0] + "=@" + PropsList[0];

            return sqlText;
        }

    }
}
