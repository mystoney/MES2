using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helper_Core
{
    /// <summary>
    /// 转换为匿名类
    /// </summary>
    public static class ToAnonymousType
    {




        /// <summary>
        /// 反序列化JSON到给定的匿名对象.
        /// </summary>
        /// <typeparam name="T">匿名对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <param name="anonymousTypeObject">匿名对象</param>
        /// <returns>匿名对象</returns>
        public static T ConvertToAnonymousType<T>(this string json, T anonymousTypeObject)
        {
            T t = JsonConvert.DeserializeAnonymousType(json, anonymousTypeObject);
            return t;
        }
    }
}
