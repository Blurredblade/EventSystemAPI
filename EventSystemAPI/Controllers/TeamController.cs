using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventSystemAPI.Models;

namespace EventSystemAPI.Controllers
{
    [Route("api/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private ESContext db;

        //Constructor that gets called every request
        public TeamController()
        {
            db = new ESContext();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "team";
        }

        // GET api/announcement/5
        [HttpGet("{id}")]
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
