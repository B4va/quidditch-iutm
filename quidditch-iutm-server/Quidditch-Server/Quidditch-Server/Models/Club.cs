using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Models
{
    public class Club
    {
        public string Name { get; private set; }

        public Club(string name)
        {
            this.Name = name;
        }
    }
}
