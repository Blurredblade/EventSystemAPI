using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSystemAPI.Models
{
    /*
     * Model for a session
     * 
     * Attributes:
     * session_id - Identifer for each session; unique per event
     * session_name - Name of the session instance
     * capacity - Capacity of the session instance
     * open_slots - The number of slots left in the session instance
     * start_date_time - Starting date and time of the session instance
     * end_date_time- Ending date and time of the session instance
     */
    public class Session
    {
        public int session_id { get; set; }
        public string session_name { get; set; }
        public int capacity { get; set; }
        public int open_slots { get; set; }
        public DateTime start_date_time { get; set; }
        public DateTime end_date_time { get; set; }
        public int event_id { get; set; }
        public bool Equals(Session s)
        {

            return session_id == s.session_id &&
                    session_name == s.session_name &&
                    capacity == s.capacity &&
                    open_slots == s.open_slots &&
                    start_date_time == s.start_date_time &&
                    end_date_time == s.end_date_time &&
                    event_id == s.event_id;
        }
    }
}
