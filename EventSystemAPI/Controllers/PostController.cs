﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventSystemAPI.Models;

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
        [ActionName("event")]
        public IActionResult CreateEvent(Event e)
        {
            db.CreateEvent(e);
            return CreatedAtRoute("GetEvent", new { e.event_id }, e);
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
        [ActionName("session")]
        public IActionResult CreateSession(Session session)
        {
            db.CreateSession(session);
            return CreatedAtRoute("GetSession", new { session.session_id }, session);
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
        [ActionName("team")]
        public IActionResult CreateTeam(Team team)
        {
            db.CreateTeam(team);
            return CreatedAtRoute("GetTeam", new { team.team_id }, team);
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
        [ActionName("user")]
        public IActionResult CreateUser(User user)
        {
            db.CreateUser(user);
            return CreatedAtRoute("GetUser", new { user.user_id }, user);
        }
    }


}