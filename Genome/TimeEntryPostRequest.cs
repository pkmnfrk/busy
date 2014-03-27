using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genome
{
    public class TimeEntryPostRequest : ApiRequest
    {
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string Note { get; set; }
        public int? ScheduleNoteID { get; set; }
        public string Type { get; set; }
        public int UserID { get; set; }
        public int? ID { get; set; }
        public int? TimeSheetCacheID { get; set; }
        public int? ReviewNote { get; set; }
        public int? ProjectID { get; set; }
        public int? TicketID { get; set; }
        public bool? IsClientBillable { get; set; }
        public string userFriendlyDuration { get; set; }


        protected override Uri EndPoint
        {
            get { return new Uri("TimeEntry", UriKind.Relative); }
        }

        public new void Send(UserContext userContext)
        {
            var result = base.Send(userContext);


        }
    }

    public enum TimeEntryType
    {
        


    }
}
