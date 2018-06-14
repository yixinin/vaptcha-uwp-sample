using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaptchaSdk.UWP.Helpers
{
    public static class JsonHelper
    {
        public static string ToJson<T>(this T obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
        public static T ToObj<T>(this string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
    }
}
