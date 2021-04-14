using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quidditch_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChampionshipController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Championship> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 20).Select(index => new Championship("Quidditch Championship ", rng.Next(2020, 2100))).ToArray();
        }
    }
}
