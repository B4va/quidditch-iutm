using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Models
{
    public class Team
    {
        public string Name { get; private set; }
        public Image Logo { get; private set; }
        public Club Club { get; private set; }
        public Championship Championship { get; private set; }

        public Team(string name, Image logo, Club club = null, Championship championship = null)
        {
            this.Name = name;
            this.Logo = logo;
            this.Club = club;
            this.Championship = championship;
        }
    }
}
