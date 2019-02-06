using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSystemAPI.Models
{
    public class Session
    {
        public int session_id { get; set; }
        public string name { get; set; }
        public int capacity { get; set; }
        public int open_slots { get; set; }
        public DateTime start_end_time { get; set; }
        public DateTime end_date_time { get; set; }
    }
}
