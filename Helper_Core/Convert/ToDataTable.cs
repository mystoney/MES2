using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Helper_Core
{
    /// <summary>
    /// 转换为DataTable的类
    /// </summary>
    public static class ToDataTable
    {
        /// <summary>
        /// List转换为DataTable
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="items">需要转换的List</param>
        /// <returns>转换完的DataTable</returns>
        public static DataTable ConvertToDataTable<T>(this List<T> items)
        {
            DataTable dataTable = new DataTable();

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }

            foreach (T obj in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(obj, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

    }
}
