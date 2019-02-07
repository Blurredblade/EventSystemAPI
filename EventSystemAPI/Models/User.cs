using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSystemAPI.Models
{
    /*
     * Model for a user
     * 
     * Attributes:
     * user_id - unique identifier for each user
     * name - the first and last name of the user instance
     * email - the email of the user instance
     * phone - the phone number of the user instance
     * isAdmin - true if the user instance has admin privileges
     */
    public class User
    {
        public int user_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int phone { get; set; }
        public bool isAdmin { get; set; }
    }
}
