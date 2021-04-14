using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Models
{
    public class Championship
    {
        public string Name { get; set; }
        public int Year { get; set; }


        public Championship(string name, int year)
        {
            this.Name = name;
            this.Year = year;
        }
    }
}
