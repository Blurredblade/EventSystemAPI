using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSystemAPI.Models
{
    /*
     * Model for an Announcement
     * 
     * Attributes:
     * announcement_id - Identifier for an announcement; unique per event
     * date_time - The time and date the announcement instance was created
     * title - Title of the announcement instance
     * message - Message of the announcement instance
     */
    public class Announcment
    {
        public int announcement_id { get; set; }
        public DateTime date_time { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public int event_id { get; set; }
    }
}
