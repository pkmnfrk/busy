using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace Genome
{
    public abstract class ApiRequest
    {
        public static Uri BaseEndPoint { get; set; }

        static ApiRequest() {
            BaseEndPoint = new Uri("http://genome.klick.com/api/");
        }

        protected abstract Uri EndPoint { get; }

        protected virtual JObject Send(UserContext userContext)
        {
            var fullUri = new Uri(BaseEndPoint, EndPoint);
            string body = JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            return Post(userContext, fullUri, body);

        }

        internal static JObject Post(UserContext userContext, Uri uri, string data)
        {

            return JObject.Parse(PostAsString(userContext, uri, data));

        }

        internal static string PostAsString(UserContext userContext, Uri uri, string data)
        {
            var wc = new WebClient();
            wc.Headers.Add("Accept", "application/json");
            wc.Headers.Add("Content-Type", "application/json");
            wc.Headers.Add(HttpRequestHeader.Cookie, userContext.Cookie);

            try
            {
                var result = wc.UploadString(uri, data);
                return result;
            }
            catch (WebException ex)
            {
                using (var sr = new StreamReader(ex.Response.GetResponseStream()))
                {
                    var result = sr.ReadToEnd();
                    return result;
                }
            }


        }

        internal static JObject Get(UserContext userContext, Uri uri)
        {
            return JObject.Parse(GetAsString(userContext, uri));


        }

        internal static string GetAsString(UserContext userContext, Uri uri)
        {
            var wc = new WebClient();
            wc.Headers.Add("Accept", "application/json");
            wc.Headers.Add("Content-Type", "application/json");
            wc.Headers.Add(HttpRequestHeader.Cookie, userContext.Cookie);

            try
            {
                var result = wc.DownloadString(uri);
                return result;
            }
            catch (WebException ex)
            {
                using (var sr = new StreamReader(ex.Response.GetResponseStream()))
                {
                    var result = sr.ReadToEnd();
                    return result;
                }
            }


        }
    }
}
