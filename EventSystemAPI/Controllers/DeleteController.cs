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
    public class DeleteController : ControllerBase
    {
        private ESContext db;

        //Constructor that gets called every request
        public DeleteController()
        {
            db = new ESContext();
        }
        
        [HttpDelete("{event_id:int}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("delete-event")]
        public void DeleteEvent(int event_id)
        {
            db.DeleteEvent(event_id);
        }

        [HttpDelete("{session_id:int}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("delete-session")]
        public void DeleteSession(int session_id)
        {
            db.DeleteSession(session_id);
        }

        [HttpDelete("{announcement_id:int}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("delete-announcement")]
        public void DeleteAnnouncement(int announcement_id)
        {
            db.DeleteAnnouncement(announcement_id);
        }

        [HttpDelete("{session_id:int}/{user_id:int}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("unregister-user")]
        public void Unregister(int session_id, int user_id)
        {
            db.RemoveUserFromSession(session_id, user_id);
        }

        [HttpDelete("{team_id:int}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("delete-team")]
        public void DeleteTeam(int team_id)
        {
            db.DeleteTeam(team_id);
        }

        [HttpDelete("{team_id:int}/{user_id:int}")]
        [EnableCors("AllowSpecificOrigin")]
        [ActionName("delete-team-user")]
        public void RemoveUserFromTeam(int team_id, int user_id)
        {
            db.RemoveUserFromTeam(team_id, user_id);
        }
    }
}
