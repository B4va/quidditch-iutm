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

        private DatabaseManager DBManager;

        public Match() 
        {
            DBManager = new DatabaseManager();
        }

        public Match(int id, string status, int homeTeamId, int visitorTeamId, string date, string time)
        {
            DBManager = new DatabaseManager();

            Id = id;
            Status = status;
            HomeTeamId = new Team().GetById(homeTeamId);
            VisitorTeamId = new Team().GetById(visitorTeamId);
            DateTime = date + " - " + time;
        }

        public List<Match> GetAllMatches()
        {
            return DBManager.QueryListResult<Match>("SELECT * FROM match", () =>
            {
                return ReaderToMatchObject();
            });
        }

        public Match GetById(int id)
        {
            return DBManager.QuerySingleObjectResult<Match>(
                string.Format("SELECT * FROM match WHERE id = '{0}'", id),
                () => ReaderToMatchObject());
        }

        private Match ReaderToMatchObject()
        {
            var id = int.Parse(DBManager.Reader[0].ToString());
            var status = DBManager.Reader[1].ToString();
            int homeTeamId = int.Parse(DBManager.Reader[2].ToString());
            int visitorTeamId = int.Parse(DBManager.Reader[3].ToString());
            var date = DBManager.Reader[4].ToString();
            var time = DBManager.Reader[5].ToString();

            return new Match(id, status, homeTeamId, visitorTeamId, date, time);
        }
    }
}
