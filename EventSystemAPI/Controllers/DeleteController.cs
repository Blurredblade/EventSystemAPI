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

    }


}
