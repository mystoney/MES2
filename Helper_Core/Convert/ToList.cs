using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;

namespace Helper_Core
{
    /// <summary>
    /// 转换为List
    /// </summary>
    public static class ToList
    {
        /// <summary>
        /// Datatable转换为List
        /// </summary>
        /// <typeparam name="T">要转换的类型</typeparam>
        /// <param name="dt">被转换的DataTable</param>
        /// <returns>转换完的List</returns>
        public static IEnumerable<T> ConvertToList<T>(this DataTable dt) where T : class, new()
        {
            // 定义集合  
            List<T> ts = new List<T>();

            // 获得此模型的类型  
            Type type = typeof(T);
            //定义一个临时变量  
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行  
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性  
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性  
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//将属性名称赋值给临时变量  
                                       //检查DataTable是否包含此列（列名==对象的属性名）    
                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter  
                        if (!pi.CanWrite) continue;//该属性不可写，直接跳出  
                                                   //取值  
                        object value = dr[tempName];
                        //如果非空，则赋给对象的属性  
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
                //对象添加到泛型集合中  
                ts.Add(t);
            }
            return ts;
        }


        /// <summary>
        /// 将json字符串转为List对象.
        /// </summary>
        /// <typeparam name="T">转换成List的类型</typeparam>
        /// <param name="json">需要转为List的json字符串</param>
        /// <returns>转换好的List对象</returns>
        public static List<T> ConvertToList<T>(this string json)
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(List<T>));
            List<T> list = o as List<T>;
            return list;

        }
    }






}
