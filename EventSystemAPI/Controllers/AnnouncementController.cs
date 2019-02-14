using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventSystemAPI.Models;

namespace EventSystemAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private ESContext db;

        //Constructor that gets called every request
        public AnnouncementController()
        {
            db = new ESContext();
        }

        // GET announcement by event
        [HttpGet("{id}")]
        [ActionName("AnnouncementByEvent")]
        public ActionResult<List<Announcment>> GetAnnouncmentsByEvent(int id)
        {
            if (db.GetAnnouncmentsByEvent(id) != null)
                return db.GetAnnouncmentsByEvent(id);
            else
                return NotFound();
        }

        // GET announcement by id
        [HttpGet("{id}")]
        [ActionName("AnnouncementById")]
        public ActionResult<Announcment> GetAnnouncement(int id)
        {
            if (db.GetAnnouncment(id) != null)
                return db.GetAnnouncment(id);
            else
                return NotFound();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


}
