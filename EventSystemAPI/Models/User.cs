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
     * password - the users instance password to log in; very insecure 
     * phone - the phone number of the user instance
     * isAdmin - true if the user instance has admin privileges
     */
    public class User
    {
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; } //need to find a better way to handle this
        public string phone { get; set; }
        public bool is_admin { get; set; }

        public bool Equals(User user)
        {
            
            return user_id == user.user_id &&
                    first_name == user.first_name &&
                    last_name == user.last_name &&
                    email == user.email &&
                    password == user.password &&
                    phone == user.phone &&
                    is_admin == user.is_admin;
        }
    }
}
