using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
    }
}