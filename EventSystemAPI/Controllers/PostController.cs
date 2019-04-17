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
    public class POSTController : ControllerBase
    {
        private ESContext db;

        //Constructor that gets called every request
        public POSTController()
        {
            db = new ESContext();
        }

        /* ROUTE esapi/event
         * POST an event into the EVENT table
         * body of the POST must be formatted as follows:
         
           {
            "address": string,
            "start_date": string,
            "end_date": string,
            "event_name": string,
            "description": string
           }

         */
        [HttpPost]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("event")]
        public IActionResult CreateEvent(Event e)
        {
            Event new_event = db.CreateEvent(e);
            return CreatedAtRoute("GetEvent", new { event_id = new_event.event_id }, new_event);
        }

        /* ROUTE esapi/session
         * POST a session into the SESSION table
         * body of the POST must be formatted as follows:
         
           {
            "session_name":string,
            "capacity":int,
            "start_date_time":datetime/string,
            "end_date_time":datetime/string,
            "event_id":int
           }

         */
        [HttpPost]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("session")]
        public IActionResult CreateSession(Session session)
        {
            Session new_session = db.CreateSession(session);
            return CreatedAtRoute("GetSession", new {session_id = new_session.session_id }, new_session);
        }

        /* ROUTE esapi/team
         * POST a team into the TEAM table
         * body of the POST must be formatted as follows:
          
           {
            "team_name":string,
            "event_id":int
           }

         */
        [HttpPost]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("team")]
        public IActionResult CreateTeam(Team team)
        {
            Team new_team = db.CreateTeam(team);
            return CreatedAtRoute("GetTeam", new { team_id = new_team.team_id }, new_team);
        }

        /* ROUTE esapi/announcement
         * POST an announcement into the ANNOUNCEMENT table
         * body of the POST must be formatted as follows:
          
           {
            "date_time":datetime/string,
            "title":string,
            "message":string,
            "event_id":int
           }

         */
        [HttpPost]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("announcement")]
        public IActionResult CreateAnnouncement(Announcement announcement)
        {
            db.CreateAnnouncement(announcement);
            return CreatedAtRoute("GetAnnouncement", new { announcement.announcement_id }, announcement);
        }

        /* ROUTE esapi/user
         * POST a user into the USER table
         * body of the POST must be formatted as follows:
          
           {
            "first_name": string,
            "last_name": string,
            "email": string,
            "password": string,
            "phone": string,
            "is_admin": bool
           }

         */
        [HttpPost]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("user")]
        public IActionResult CreateUser(User user)
        {
            User new_user = db.CreateUser(user);
            return CreatedAtRoute("GetUser", new { user_id = new_user.user_id }, new_user);
        }
        
        [HttpPost("{session_id:int}/{user_id:int}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("register-user")]
        public IActionResult RegisterUser(int session_id, int user_id)
        {
            db.RegisterUser(session_id, user_id);
            return NoContent();
        }

        
    }


}
