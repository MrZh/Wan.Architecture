using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace Wan.Infrastructure.Extends
{
    public static class PropertyInfoExtend
    {

        /// <summary>
        /// 是否是主键
        /// </summary>
        /// <param name="propertyInfo">属性字段</param>
        /// <returns>是否主键</returns>
        public static bool IsPrimaryKey(this PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes().OfType<KeyAttribute>().Any();
        }

        /// <summary>
        /// 获得表字段
        /// </summary>
        /// <param name="propertyInfo">属性字段</param>
        /// <param name="isPrimaryKey">是否是主键</param>
        /// <returns></returns>
        public static string GetColumnName(this PropertyInfo propertyInfo, out bool isPrimaryKey)
        {
            isPrimaryKey = false;
            foreach (var item in propertyInfo.GetCustomAttributes())
            {

                if (item is KeyAttribute)
                {
                    isPrimaryKey = true;
                }
                else
                {
                    var attribute = item as ColumnAttribute;
                    if (attribute == null) continue;
                    var columnAttribute = attribute;
                    return columnAttribute.Name;
                }
            }

            return "";
        }

        /// <summary>
        /// 获得表字段
        /// </summary>
        /// <param name="propertyInfo">属性字段</param>
        /// <returns></returns>
        public static string GetColumnName(this PropertyInfo propertyInfo)
        {
            foreach (var item in propertyInfo.GetCustomAttributes())
            {
                if (!(item is ColumnAttribute)) continue;
                var columnAttribute = item as ColumnAttribute;
                return columnAttribute.Name;
            }

            return "";
        }
    }
}
