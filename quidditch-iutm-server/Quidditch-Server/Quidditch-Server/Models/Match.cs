using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Models
{
    public class Match
    {
        public Team HomeTeam { get; private set; }
        public Team VisitorTeam { get; private set; }
        public DateTime DateTime { get; private set; }
        public MatchStatus Status { get; private set; }

        public Match(Team homeTeam, Team visitorTeam, DateTime dateTime,  MatchStatus status)
        {
            this.HomeTeam = homeTeam;
            this.VisitorTeam = visitorTeam;
            this.DateTime = dateTime;
            this.Status = status;
        }
    }

    public enum MatchStatus
    {
        PLANNED = 1,
        ONGOING = 2,
        FINISHED = 3,
        POSTPONED = 4,
        CANCELED = 5
    }
}
