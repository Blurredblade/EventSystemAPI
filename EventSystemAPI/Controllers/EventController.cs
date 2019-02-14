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
    public class EventController : ControllerBase
    {
        private ESContext db;

        //Constructor that gets called every request
        public EventController()
        {
            db = new ESContext();
        }

        //TESTED AND WORKED
        // GET all events
        [HttpGet]
        [ActionName("GetAll")]
        public ActionResult<List<Event>> GetEventsList()
        {
            if (db.GetEventsList() != null)
                return db.GetEventsList();
            else
                return NotFound();
        }

        //DOESNT WORK
        // GET all events by user id
        [HttpGet("{id}")]
        [ActionName("EventByUserId]")]
        public ActionResult<List<Event>> GetEventsList(int id)
        {
            if (db.GetEventsList(id) != null)
                return db.GetEventsList(id);
            else
                return NotFound();
        }

        //TESTED AND WORKED
        // GET event by id
        [HttpGet("{id}")]
        [ActionName("EventById")]
        public ActionResult<Event> GetEvent(int id)
        {
            if (db.GetEvent(id) != null)
                return db.GetEvent(id);
            else
                return NotFound();
        }

        //TESTED AND WORKED
        // GET event with sessions
        [HttpGet("{id}")]
        [ActionName("EventByIdWithSessions")]
        public ActionResult<Event> GetEventWithSessions(int id)
        {
            if (db.GetEventWithSessions(id) != null)
                return db.GetEventWithSessions(id);
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
