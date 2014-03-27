using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace Genome
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int ProjectID { get; set; }

        public static Ticket GetTicketById(UserContext context, int ticketid)
        {

            var uri = new Uri(ApiRequest.BaseEndPoint, "Ticket?TicketID=" + ticketid);
            var json = ApiRequest.Get(context, uri);

            if (json["NumEntries"] == null) return null;

            if (json["NumEntries"].Value<int>() > 0)
            {
                return json["Entries"][0].ToObject<Ticket>();
            }

            return null;

        }
    }


}
