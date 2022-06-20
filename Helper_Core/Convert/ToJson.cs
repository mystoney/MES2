using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Helper_Core
{
    /// <summary>
    /// 转换为Json
    /// </summary>
    public static class  ToJson
    {


        /// <summary>
        /// 将对象转为json
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="Model">需要转换的对象</param>
        /// <returns>格式化好的json字符串</returns>
        public static string ConvertToJson<T>(this T Model)
        {
            JsonSerializerSettings JSS = new JsonSerializerSettings();

            JSS.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; //循环引用忽略
            JSS.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;//空值不导


            string json = JsonConvert.SerializeObject(Model, Formatting.Indented, JSS);
            return json;
        }
    }
}
