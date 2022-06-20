using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper.Enum_All
{
    /// <summary>
    /// 枚举类
    /// </summary>
    public class Enum_type
    {
        /// <summary>
        /// 取枚举中的所有项
        /// </summary>
        /// <returns>枚举中所有枚举项的名称数组</returns>
        public static List<string> Enum_Array<T>() where T : struct
        {
            Type t = typeof(T);
            Array arrays = Enum.GetValues(t);

            List<string> ak = new List<string>();

            foreach (var item in arrays)
            {
                ak.Add(item.ToString());
            }

            return ak;
        }

        /// <summary>
        /// 返回枚举的值
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="Enumstring">枚举中的名称</param>
        /// <returns>传入名称的值</returns>
        public static int Enum_Int<T>(string Enumstring) where T : struct
        {
            int I = (int)Enum.Parse(typeof(T), Enumstring);
            return I;
        }
    }
}
