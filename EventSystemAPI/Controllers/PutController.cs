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
    public class PUTController : ControllerBase
    {
        private ESContext db;

        //Constructor that gets called every request
        public PUTController()
        {
            db = new ESContext();
        }

        /* ROUTE esapi/event
         * Update an event
         * body of the PUT must be formatted as follows:
           {
            "event_id":int,
            "address": string,
            "start_date": string,
            "end_date": string,
            "event_name": string,
            "description": string
           }
         */
        [HttpPut]
        [ActionName("event")]
        public string UpdateEvent(Event e)
        {
            db.UpdateEvent(e);
            return "Event " + e.event_id + " updated";
        }
        
    }


}
