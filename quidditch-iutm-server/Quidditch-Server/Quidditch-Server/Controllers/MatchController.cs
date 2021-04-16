using Microsoft.AspNetCore.Mvc;
using Quidditch_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Controllers
{
    [ApiController]
    public class MatchController : ControllerBase
    {
        [HttpGet]
        [Route("api/matches")]
        public IEnumerable<Match> GetAll()
        {
            return Match.GetAllMatches();
        }

        [HttpGet]
        [Route("api/matches/{id}")]
        public Match GetById(int id)
        {
            return Match.GetById(id);
        }
    }
}
