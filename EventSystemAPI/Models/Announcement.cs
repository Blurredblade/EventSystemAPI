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
    public class Announcement
    {
        public int announcement_id { get; set; }
        public DateTime date_time { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public int event_id { get; set; }

        public bool Equals(Announcement a)
        {

            return announcement_id == a.announcement_id &&
                    date_time == a.date_time &&
                    title == a.title && 
                    message == a.message &&
                    event_id == a.event_id;
        }
    }
}
