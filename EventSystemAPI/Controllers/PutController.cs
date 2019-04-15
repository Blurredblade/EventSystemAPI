using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventSystemAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace EventSystemAPI.Controllers
{
    [Route("esapi/[action]")]
    [ApiController]
    public class PUTController : ControllerBase
    {
        private ESContext db;

        //Constructor that gets called every request
        public PUTController()
        {
            db = new ESContext();
        }

        /* ROUTE esapi/event
         * Update an event
         * body of the PUT must be formatted as follows:
           {
            "event_id":int,
            "address": string,
            "start_date": string,
            "end_date": string,
            "event_name": string,
            "description": string
           }
         */
        [HttpPut]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("event")]
        public string UpdateEvent(Event e)
        {
            db.UpdateEvent(e);
            return "Event " + e.event_id + " updated";
        }

        /* ROUTE esapi/session
         * POST a session into the SESSION table
         * body of the POST must be formatted as follows:

           {
            "session_name":string,
            "capacity":int,
            "start_date_time":datetime/string,
            "end_date_time":datetime/string,
            "session_id":int
           }

         */

        [HttpPut]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("session")]
        public string UpdateSession(Session session)
        {
            db.UpdateSession(session);
            return "Session " + session.event_id + " updated";
        }

        [HttpPut("{session_id:int}/{user_id:int}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("check-in-user")]
        public IActionResult CheckInUser(int session_id, int user_id)
        {
            db.CheckInUser(session_id, user_id);
            return NoContent();
        }

        [HttpPut]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("user")]
        public string UpdateUser(User user)
        {
            User updated_user = db.UpdateUser(user);

            if (updated_user == null)
            {
                return "The specified user does not exist.";
            }else if (user.Equals(updated_user))
            {
                return "No changes were made.";
            }
            else
            {
                return "Account information sucessfully updated.";
            }
        }

    }


}
