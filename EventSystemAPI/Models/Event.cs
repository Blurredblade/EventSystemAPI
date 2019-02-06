using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSystemAPI.Models
{
    /* 
     * Model for an Event
     * 
     * Attributes:
     * event_id - Unique identifier for each event
     * address - Address registered for the event instance
     * start_date -  Starting date set for the event instance
     * end_date - Ending date set for the event instance
     * event_name - Name of the event instance
     * description - Description of the event instance
     * sessions - A list of all sessions registered to the event instance
     */
    public class Event
    {
        public int event_id { get; set; }
        public string address { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string event_name { get; set; }
        public string description { get; set; }
        public List<Session> sessions { get; set; }
    }
}
