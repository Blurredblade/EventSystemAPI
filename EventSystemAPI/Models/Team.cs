﻿using System;
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
        public int event_id { get; set; }
        public int[] members { get; set; }
        public int memberCount { get; set; }
        public bool Equals(Team t)
        {

            return team_id == t.team_id &&
                    team_name == t.team_name &&
                    event_id == t.event_id;
        }
    }
}
