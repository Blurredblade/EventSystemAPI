using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSystemAPI.Models
{
    /*
     * Model for a team
     * 
     * Attributes:
     * team_id - unique identifier for each team
     * team_name - name of the team instance
     * members - a list of Users on the team instance
     */
    public class Team
    {
        public int team_id { get; set; }
        public string team_name { get; set; }
        public List<User> members { get; set; }
        public int event_id { get; set; }
    }
}
