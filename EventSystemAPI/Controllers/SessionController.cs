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
    public class SessionController : ControllerBase
    {
        private ESContext db;

        //Constructor that gets called every request
        public SessionController()
        {
            db = new ESContext();
        }

        //RETURNS EMPTY
        // GET all sessions by event
        [HttpGet("{id}")]
        [ActionName("SessionByEvent")]
        public ActionResult<List<Session>> GetSessionsByEvent(int event_id)
        {
            if (db.GetSessionsByEvent(event_id) != null)
                return db.GetSessionsByEvent(event_id);
            else
                return NotFound();
        }

        //TESTED AND WORKED
        // GET session by id
        [HttpGet("{id}")]
        [ActionName("SessionById")]
        public ActionResult<Session> GetSession(int id)
        {
            if (db.GetSession(id) != null)
                return db.GetSession(id);
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
