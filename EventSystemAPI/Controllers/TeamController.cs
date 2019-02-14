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
    public class TeamController : ControllerBase
    {
        private ESContext db;

        //Constructor that gets called every request
        public TeamController()
        {
            db = new ESContext();
        }

        //TESTED AND WORKED
        // GET team by id
        [HttpGet("{id}")]
        [ActionName("TeamById")]
        public ActionResult<Team> GetTeam(int id)
        {
            if (db.GetTeam(id) != null)
                return db.GetTeam(id);
            else
                return NotFound();
        }

        //RETURNS EMPTY
        // GET team by event
        [HttpGet("{id}")]
        [ActionName("TeamByEvent")]
        public ActionResult<List<Team>> GetTeamsByEvent(int event_id)
        {
            if (db.GetTeamsByEvent(event_id) != null)
                return db.GetTeamsByEvent(event_id);
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
