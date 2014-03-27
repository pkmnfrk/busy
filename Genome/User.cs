using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Genome
{
    public class User
    {
        public int UserID { get; set; }
        public int UserSystemID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }

        public static User GetCurrentUser(UserContext context)
        {
            var uri = new Uri(ApiRequest.BaseEndPoint, "User?CurrentUser=true");
            var json = ApiRequest.Get(context, uri);

            if (json["NumEntries"] == null) return null;

            if (json["NumEntries"].Value<int>() > 0)
            {
                return json["Entries"][0].ToObject<User>();
            }
            
            return null;
        }
    }
}
