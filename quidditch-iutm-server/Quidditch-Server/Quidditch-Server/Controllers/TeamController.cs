using Microsoft.AspNetCore.Mvc;
using Quidditch_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Controllers
{
    [ApiController]
    public class TeamController : ControllerBase
    {
        [HttpGet]
        [Route("api/teams")]
        public IEnumerable<Team> GetAll()
        {
            return new Team().GetAllTeams();
        }

        [HttpGet]
        [Route("api/teams/{id}")]
        public Team GetById(int id)
        {
            return new Team().GetById(id);
        }
    }
}
