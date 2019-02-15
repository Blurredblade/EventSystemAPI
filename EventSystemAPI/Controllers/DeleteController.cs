using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventSystemAPI.Models;

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
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


}
