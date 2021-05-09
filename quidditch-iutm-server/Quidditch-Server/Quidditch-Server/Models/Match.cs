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
        public Team HomeTeam { get; set; }
        public Team VisitorTeam { get; set; }

        //Needs to be done correctly with the DateTime Class
        public string DateTime { get; set; }

        public int HomeTeamScore { get; set; }
        public int VisitorTeamScore { get; set; }
        public int GoldSnitch { get; set; }
        public List<Event> Events { get; set; }

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
            HomeTeam = new Team().GetById(homeTeamId);
            VisitorTeam = new Team().GetById(visitorTeamId);
            DateTime = date + " - " + time;
            HomeTeamScore = GetTeamScore(HomeTeam.Id);
            VisitorTeamScore = GetTeamScore(VisitorTeam.Id);
            GoldSnitch = GetGoldenSnitch();
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

        public int GetTeamScore(int teamId)
        {
            return DBManager.QueryIntResult(
                "SELECT COUNT(*) " +
                "FROM event e " +
                "INNER JOIN player p on e.player_id = p.id " +
                "INNER JOIN team t on p.club_id = t.club_id " +
                "INNER JOIN club c on c.id = p.club_id " +
                $"WHERE match_id = {Id} " +
                "AND e.type = 0 " +
                $"AND c.id = {teamId}");
        }

        public int GetGoldenSnitch()
        {
            return DBManager.QueryIntResult(
                "SELECT t.id " +
                "FROM event e " +
                "INNER JOIN player p on e.player_id = p.id " +
                "INNER JOIN team t on p.club_id = t.club_id " +
                $"WHERE match_id = {Id} " +
                "AND e.type = 2 ");
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
