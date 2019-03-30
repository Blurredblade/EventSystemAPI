using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EventSystemAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace EventSystemAPI.Controllers
{
    [Route("esapi/[action]")]
    [ApiController]
    public class GetController : ControllerBase
    {
        private ESContext db;
        
        //Constructor that gets called every request
        public GetController()
        {
            db = new ESContext();
        }

        /*\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
         *\\\\\\\\\\\\\\ EVENT METHODS \\\\\\\\\\\\\\\\\
         *\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\*/

        /* ROUTE esapi/all-events/{user_id}(optional)
         * GET all events with an optional user id
         * 
         * Returns the list of all events in the system
         * or if the optional user_id is put in it returns 
         * a list of all events the user is attending
         */
        [HttpGet("{user_id:int?}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("all-events")]
        public ActionResult<List<Event>> GetEventsList(int user_id)
        {
            List<Event> events;
            if (user_id != 0)
            {
                events = db.GetEventsList(user_id);
            }
            else
            {
                events = db.GetEventsList();
            }

            if (events == null)
            {
                return NotFound();
            }
            return events;
        }


        /* ROUTE esapi/event/{event_id}
        * GET an event by its id
        */
        [HttpGet("{event_id:int}", Name = "GetEvent")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("event")]
        public ActionResult<Event> GetEvent(int event_id)
        {
            Event e = db.GetEvent(event_id);
            if (e == null)
            {
                return NotFound();
            }
            return e;
        }

        /*\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
         *\\\\\\\\\\\\\ SESSION METHODS \\\\\\\\\\\\\\\\
         *\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\*/

        /* ROUTE esapi/event-sessions/{event_id}
        * GET all the sessions in an event
        */
        [HttpGet("{event_id:int}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("event-sessions")]
        public ActionResult<List<Session>> GetSessionsByEvent(int event_id)
        {
            List<Session> sessions = db.GetSessionsByEvent(event_id);
            if (sessions == null)
            {
                return NotFound();
            }
            return sessions;
        }

        /* ROUTE esapi/event-sessions/{session_id}
         * GET a session by id
         */
        [HttpGet("{session_id}", Name ="GetSession")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("session")]
        public ActionResult<Session> GetSession(int session_id)
        {
            Session session = db.GetSession(session_id);
            if (session == null)
            {
                return NotFound();
            }
            return session;
        }

        [HttpGet("{user_id:int}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("user-sessions")]
        public ActionResult<List<Session>> GetUsersSessionList(int user_id)
        {
            List<Session> sessions;
            sessions = db.GetUsersSessionsList(user_id);
            if (sessions == null)
            {
                return NotFound();
            }
            return sessions;
        }

        /*\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
         *\\\\\\\\\\\\\\\ TEAM METHODS \\\\\\\\\\\\\\\\\
         *\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\*/

        /* ROUTE esapi/team/{team_id}
         * GET a team by id
         */
        [HttpGet("{team_id:int}", Name = "GetTeam")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("team")]
        public ActionResult<Team> GetTeam(int team_id)
        {
            Team team = db.GetTeam(team_id);
            if (team == null)
            {
                return NotFound();
            }
            return team;
        }

        /* ROUTE esapi/event-teams/{event_id}
         * GET a list of teams for an event
         */
        [HttpGet("{event_id:int}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("event-teams")]
        public ActionResult<List<Team>> GetTeamsByEvent(int event_id)
        {
            List<Team> teams = db.GetTeamsByEvent(event_id);
            if(teams == null)
            {
                return NotFound();
            }
            return teams;
        }

        /*\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
         *\\\\\\\\\\\ ANNOUNCEMENT METHODS \\\\\\\\\\\\\
         *\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\*/

        /* ROUTE esapi/event-announcements/{event_id}
         * GET a list of announcements for an event
         */
        [HttpGet("{event_id:int}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("event-announcements")]
        public ActionResult<List<Announcement>> GetAnnouncementsByEvent(int event_id)
        {
            List<Announcement> announcements = db.GetAnnouncementsByEvent(event_id);
            if(announcements == null)
            {
                return NotFound();
            }
            return announcements;
        }

        /* ROUTE esapi/announcement/{announcement_id}
         * GET an announcement by id
         */
        [HttpGet("{announcement_id:int}", Name = "GetAnnouncement")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("announcement")]
        public ActionResult<Announcement> GetAnnouncement(int announcement_id)
        {
            Announcement announcement = db.GetAnnouncement(announcement_id);
            if(announcement == null)
            {
                return NotFound();
            }
            return announcement;
        }

        [HttpGet("{user_id:int}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("recent-announcement")]
        public ActionResult<List<Announcement>> GetRecentAnnouncementsByUser(int user_id)
        {
            List<Announcement> announcement = db.GetRecentAnnouncementsByUser(user_id);
            if (announcement == null)
            {
                return NotFound();
            }
            return announcement;
        }


        /*\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
         *\\\\\\\\\\\\\\\ USER METHODS \\\\\\\\\\\\\\\\\
         *\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\*/

        /* ROUTE esapi/user/{user_id}
         * GET a user by id
         */
        [HttpGet("{user_id:int}", Name = "GetUser")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("user")]
        public ActionResult<User> GetUser(int user_id)
        {
            User user = db.GetUser(user_id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        /* ROUTE esapi/team-users/{team_id}
         * GET list of all users on a team
         */
        [HttpGet("{team_id:int}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("team-users")]
        public ActionResult<List<User>> GetTeamUsers(int team_id)
        {
            List<User> users = db.GetTeamUsers(team_id);
            if(users == null)
            {
                return NotFound();
            }
            return users;
        }

        /* ROUTE esapi/team-users/{team_id}
 * GET list of all users on a team
 */
        [HttpGet("{session_id:int/user_id:int}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("team-session-users")]
        public ActionResult<List<User>> GetRegisteredTeamUsers(int user_id, int session_id)
        {
            List<User> users = db.GetRegisteredTeamUsers(user_id, session_id);
            if (users == null)
            {
                return NotFound();
            }
            return users;
        }


        /* ROUTE esapi/session-users/{session_id}
         * GET list of all users attending the given session
         */
        [HttpGet("{session_id:int}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("session-users")]
        public ActionResult<List<User>> GetSessionUsers(int session_id)
        {
            List<User> users = db.GetSessionUsers(session_id);
            if(users == null)
            {
                return NotFound();
            }
            return users;
        }

        /* ROUTE esapi/session-users/{session_id}
         * GET list of all users attending the given session
         */
        [HttpGet("{event_id:int}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("event-users")]
        public ActionResult<List<User>> GetEventUsers(int event_id)
        {
            List<User> users = db.GetEventUsers(event_id);
            if (users == null)
            {
                return NotFound();
            }
            return users;
        }

        /* ROUTE esapi/userlogin/{email}/{password}
        * GET a user by email and password
        */
        [HttpGet("{email}/{password}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("userlogin")]
        public ActionResult<User> GetUser(string email, string password)
        {
            User user = db.GetUser(email, password);
            if (user == null)
            {
                //return null;
                return NotFound();
            }
            return user;
        }

    }
}
