using Microsoft.AspNetCore.Mvc;
using Quidditch_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Controllers
{
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpGet]
        [Route("api/events")]
        public IEnumerable<Event> GetAll()
        {
            return new Event().GetAllEvents();
        }

        [HttpGet]
        [Route("api/events/{id}")]
        public Event GetById(int id)
        {
            return new Event().GetById(id);
        }
    }
}
