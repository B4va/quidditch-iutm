using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Models
{
    public class Event
    {
        public DateTime Time { get; private set; }
        public string Description { get; private set; }
        public string Type { get; private set; }
        public Match Match { get; private set; }
        public Player Player { get; private set; }

        public Event(DateTime time, string description, string type, Match match, Player player)
        {
            Time = time;
            Description = description;
            Type = type;
            Match = match;
            Player = player;
        }
    }
}
