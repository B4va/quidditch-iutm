using Npgsql;
using Quidditch_Server.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Int64 Logo { get; set; }
        public Championship Championship { get; set; }
        public Club Club { get; set; } 
        public List<Match> Matches { get; set; }

        private DatabaseManager DBManager;

        public Team()
        {
            DBManager = new DatabaseManager();
        }

        public Team(int id, string name, Int64 logo, int championshipId, int clubId)
        {
            DBManager = new DatabaseManager();

            this.Id = id;
            this.Name = name;
            this.Logo = logo;
            this.Championship = new Championship().GetById(championshipId);
            this.Club = new Club().GetById(clubId);
        }

        public List<Team> GetAllTeams()
        {
            return DBManager.QueryListResult("SELECT * FROM team", () =>
            {
                return ReaderToTeamObject();
            });
        }

        public Team GetById(int id)
        {
            return DBManager.QuerySingleObjectResult<Team>(
                string.Format("SELECT * " +
                              "FROM team " +
                              "WHERE id = '{0}'",
                              id),
                () => ReaderToTeamObject());
        }

        public List<Team> GetTeamsByChampionshipId(int id)
        {
            return DBManager.QueryListResult<Team>(
                string.Format("SELECT * " +
                              "FROM team " +
                              "WHERE team.championship_id = {0} ",
                              id),
                () => ReaderToTeamObject());
        }

        private Team ReaderToTeamObject()
        {
            var id = int.Parse(DBManager.Reader[0].ToString());
            var name = DBManager.Reader[1].ToString();
            Int64 logo = 0; //logo = Int64.Parse(DBManager.Reader[2].ToString()); problème de format string à régler
            var championshipId = int.Parse(DBManager.Reader[3].ToString());
            var clubId = int.Parse(DBManager.Reader[4].ToString());

            return new Team(id, name, logo, championshipId, clubId);
        }
    }
}
