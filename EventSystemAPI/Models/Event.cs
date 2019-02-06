using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSystemAPI.Models
{
    public class Event
    {
        public int event_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
    }
}
