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
            return new Championship().GetAllChampionships();
        }

        [HttpGet]
        [Route("api/championships/last")]
        public Championship GetLast()
        {
            Championship lastChampionship = new Championship().GetLast();

            lastChampionship.Teams = new Team().GetTeamsByChampionshipId(lastChampionship.Id);

            return lastChampionship;
        }

        [HttpGet]
        [Route("api/championships/{id}")]
        public Championship GetById(int id)
        {
            Championship championship = new Championship().GetById(id);

            championship.Teams = new Team().GetTeamsByChampionshipId(championship.Id);

            return championship;
        }
    }
}
