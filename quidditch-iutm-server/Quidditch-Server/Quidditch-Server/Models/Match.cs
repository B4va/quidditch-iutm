using Npgsql;
using Quidditch_Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public Team HomeTeamId { get; set; }
        public Team VisitorTeamId { get; set; }

        //Needs to be done correctly with the DateTime Class
        public string DateTime { get; set; }

        public Match(int id, string status, int homeTeamId, int visitorTeamId, string date, string time)
        {
            Id = id;
            Status = status;
            HomeTeamId = Team.GetById(homeTeamId);
            VisitorTeamId = Team.GetById(visitorTeamId);
            DateTime = date + " - " + time;
        }

        public static List<Match> GetAllMatches()
        {
            return DatabaseManager.QueryListResult<Match>("SELECT * FROM team", () =>
            {
                return ReaderToMatchObject();
            });
        }

        public static Match GetById(int id)
        {
            return DatabaseManager.QuerySingleObjectResult<Match>(
                string.Format("SELECT * FROM match WHERE id = '{0}'", id),
                () => ReaderToMatchObject());
        }

        private static Match ReaderToMatchObject()
        {
            var id = int.Parse(DatabaseManager.Reader[0].ToString());
            var status = DatabaseManager.Reader[1].ToString();
            var test = DatabaseManager.Reader[2];
            int homeTeamId = int.Parse(DatabaseManager.Reader[2].ToString());
            int visitorTeamId = int.Parse(DatabaseManager.Reader[3].ToString());
            var date = DatabaseManager.Reader[4].ToString();
            var time = DatabaseManager.Reader[5].ToString();

            return new Match(id, status, homeTeamId, visitorTeamId, date, time);
        }
    }
}
