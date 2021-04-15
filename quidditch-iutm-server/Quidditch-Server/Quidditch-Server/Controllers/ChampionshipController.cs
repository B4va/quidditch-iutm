using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Quidditch_Server.Models;
using Quidditch_Server.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Controllers
{
    [ApiController]
    public class ChampionshipController : ControllerBase
    {
        [HttpGet]
        [Route("api/championships")]
        public IEnumerable<Championship> GetAll()
        {
            return Championship.GetAllChampionships();
        }

        [HttpGet]
        [Route("api/championships/last")]
        public Championship GetLast()
        {
            return Championship.GetLast();
        }

        [HttpGet]
        [Route("api/championships/{id}")]
        public Championship GetById(int id)
        {
            return Championship.GetById(id);
        }
    }
}
