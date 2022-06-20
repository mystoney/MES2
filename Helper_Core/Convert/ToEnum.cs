using System;
using System.Collections.Generic;
using System.Text;

namespace Helper_Core
{
    /// <summary>
    /// 转换为枚举
    /// </summary>
    public static class ToEnum
    {
        /// <summary>
        /// 将字符转为枚举
        /// </summary>
        /// <typeparam name="T">转换成的枚举类型</typeparam>
        /// <param name="s">需要转换的字符</param>
        /// <returns>转化好的枚举</returns>
        public static T ConvertToEnum<T>(this string s)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }



            //enumColor color = enumColor.Red;
            try
            {
                return (T)Enum.Parse(typeof(T), s);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
            }

            
        }

        /// <summary>
        /// 将整数转为枚举
        /// </summary>
        /// <typeparam name="T">转换成的枚举类型</typeparam>
        /// <param name="s">需要转换的整数</param>
        /// <returns></returns>

        public static T ConvertToEnum<T>(this int s)
        {
            try
            {
                return (T)Enum.ToObject(typeof(T), s);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }



           


        }
    }
}
