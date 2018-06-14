using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace VaptchaSdk.UWP.Helpers
{
    public class HttpHelper
    {
        public static async Task<string> GetAsync(string url)
        {
            var hc = new HttpClient();
            return await hc.GetStringAsync(new Uri(url));
        }
        public static async Task<string> PostAsync(string url, string data)
        {
            var hc = new HttpClient();
            var content = new HttpStringContent(data, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
            var response = await hc.PostAsync(new Uri(url), content);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
