using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wan.Infrastructure.Commands;

namespace Wan.Infrastructure.Extends
{
    public static class TypeExtend
    {
        /// <summary>
        /// 获得当前的TableName
        /// </summary>
        /// <param name="classType">type</param>
        /// <returns>表名称</returns>
        public static string GetTableName(this Type classType)
        {
            var strTableName = string.Empty;

            var strEntityName = classType.FullName;

            foreach (var item in classType.GetCustomAttributes(false))
            {
                if (!(item is TableAttribute)) continue;
                var tableAttr = item as TableAttribute;
                strTableName = tableAttr.Name;
                break;
            }


            if (string.IsNullOrEmpty(strTableName))
            {
                throw new Exception("实体类:" + strEntityName + "的属性配置[Table(name=\"tablename\")]错误或未配置");
            }
            return strTableName;
        }

        /// <summary>
        /// 获得所有的属性字段,id放到第一个,如果没有主键返回Null
        /// </summary>
        /// <param name="classType"></param>
        /// <returns></returns>
        public static List<string> GetPropsList(this Type classType)
        {
            //ColumnList = new List<string>();
            var propsList = new List<string>();
            var ps = classType.GetProperties();
            var hasKey = false;
            foreach (var i in ps)
            {
                var isKey = i.IsPrimaryKey();
                if (isKey)
                {
                    hasKey = true;
                    propsList.Insert(0, i.Name);
                }
                else
                {
                    propsList.Add(i.Name);
                }

            }
            return !hasKey ? null : propsList;
        }

        /// <summary>
        /// 获得当前类型的Sql语句
        /// </summary>
        /// <param name="classType">当前type</param>
        /// <param name="commandEnum">sql类型</param>
        /// <returns></returns>
        public static string GetSql(this Type classType, CommandEnum commandEnum = CommandEnum.Insert)
        {
            List<string> propsList = new List<string>();
            System.Reflection.PropertyInfo[] ps = classType.GetProperties();
            String tableName = classType.GetTableName();

            foreach (PropertyInfo i in ps)
            {
                bool isKey = i.IsPrimaryKey();
                if (isKey)
                {
                    propsList.Insert(0, i.Name);
                }
                else
                {
                    propsList.Add(i.Name);
                }

            }
            if (commandEnum.Equals(CommandEnum.Insert))
            {
                String sqlText = "insert into " + tableName + "(";
                String valueText = " values ( ";
                foreach (string props in propsList)
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

            if (commandEnum.Equals(CommandEnum.Update))
            {
                String sqlText = "update " + tableName + " set ";
                for (int i = 1; i < propsList.Count; i++)
                {
                    sqlText = sqlText + propsList[i] + "=@" + propsList[i] + ",";
                }

                sqlText = sqlText.Substring(0, sqlText.Length - 1);
                sqlText += " where " + propsList[0] + "=@" + propsList[0];

                return sqlText;
            }

            if (commandEnum.Equals(CommandEnum.Delete))
            {
                String sqlText = "delete from " + tableName;
                sqlText += " where " + propsList[0] + "=@" + propsList[0];

                return sqlText;
            }

            return null;
        }

        /// <summary>
        /// 获得当前类型的Sql语句
        /// </summary>
        /// <typeparam name="T">当前type</typeparam>
        /// <param name="classType">当前type</param>
        /// <param name="type">当前type的对象</param>
        /// <param name="commandEnum">sql类型</param>
        /// <returns></returns>
        public static string GetSql<T>(this Type classType, T type, CommandEnum commandEnum = CommandEnum.Insert)
        {
            if (typeof(T) != classType)
            {
                return null;
            }
            List<string> propsList = new List<string>();
            System.Reflection.PropertyInfo[] ps = classType.GetProperties();
            String tableName = classType.GetTableName();
            if (type == null)
            {
                foreach (PropertyInfo i in ps)
                {
                    bool isKey = i.IsPrimaryKey();
                    if (isKey)
                    {
                        propsList.Insert(0, i.Name);
                    }
                    else
                    {
                        propsList.Add(i.Name);
                    }

                }
            }
            else
            {
                foreach (PropertyInfo i in ps)
                {
                    var temp = i.GetValue(type);
                    if (temp != null)
                    {
                        bool isKey = i.IsPrimaryKey();
                        if (isKey)
                        {
                            propsList.Insert(0, i.Name);
                        }

                        else
                        {
                            propsList.Add(i.Name);
                        }
                    }
                }
            }

            if (commandEnum.Equals(CommandEnum.Insert))
            {
                String sqlText = "insert into " + tableName + "(";
                String valueText = " values ( ";
                foreach (string props in propsList)
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

            if (commandEnum.Equals(CommandEnum.Update))
            {
                String sqlText = "update " + tableName + " set ";
                for (int i = 1; i < propsList.Count; i++)
                {
                    sqlText = sqlText + propsList[i] + "=@" + propsList[i] + ",";
                }

                sqlText = sqlText.Substring(0, sqlText.Length - 1);
                sqlText += " where " + propsList[0] + "=@" + propsList[0];

                return sqlText;
            }

            if (commandEnum.Equals(CommandEnum.Delete))
            {
                String sqlText = "delete from " + tableName;
                sqlText += " where " + propsList[0] + "=@" + propsList[0];

                return sqlText;
            }

            return null;
        }
    }
}