using Microsoft.AspNetCore.Mvc;
using Quidditch_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Controllers
{
    [ApiController]
    public class ClubController : ControllerBase
    {
        [HttpGet]
        [Route("api/clubs")]
        public IEnumerable<Club> GetAll()
        {
            return new Club().GetAllClubs();
        }

        [HttpGet]
        [Route("api/clubs/{id}")]
        public Club GetById(int id)
        {
            return new Club().GetById(id);
        }
    }
}
