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
    public class UserController : ControllerBase
    {
        private ESContext db;

        //Constructor that gets called every request
        public UserController()
        {
            db = new ESContext();
        }

        //CONTROLLER OR SOMETHING DOESNT WORK http 500
        // GET user by team
        [HttpGet("{id}")]
        [ActionName("UserByTeam")]
        public ActionResult<List<User>> GetTeamUsers(int id)
        {
            if (db.GetTeamUsers(id) != null)
                return db.GetTeamUsers(id);
            else
                return NotFound();
        }

        //CONTROLLER OR SOMETHING DOESNT WORK http 500
        // GET user by id
        [HttpGet("{id}")]
        [ActionName("UserById")]
        public ActionResult<User> GetUser(int id)
        {
            if (db.GetUser(id) != null)
                return db.GetUser(id);
            else
                return NotFound();
        }

        //CONTROLLER OR SOMETHING DOESNT WORK http 500
        // GET user by session
        [HttpGet("{id}")]
        [ActionName("UserBySession")]
        public ActionResult<List<User>> GetSessionUsers(int id)
        {
            if (db.GetSessionUsers(id) != null)
                return db.GetSessionUsers(id);
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
