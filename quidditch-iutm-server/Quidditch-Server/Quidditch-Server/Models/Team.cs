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

        public Team(int id, string name, Int64 logo, int championshipId, int clubId)
        {
            this.Id = id;
            this.Name = name;
            this.Logo = logo;
            this.Championship = Championship.GetById(championshipId);
            this.Club = Club.GetById(clubId);
        }

        public static List<Team> GetAllTeams()
        {
            return DatabaseManager.QueryListResult("SELECT * FROM team", () =>
            {
                return ReaderToTeamObject();
            });
        }

        public static Team GetById(int id)
        {
            return DatabaseManager.QuerySingleObjectResult<Team>(
                string.Format("SELECT * FROM team WHERE id = '{0}'", id),
                () => ReaderToTeamObject());
        }

        private static Team ReaderToTeamObject()
        {
            var id = int.Parse(DatabaseManager.Reader[0].ToString());
            var name = DatabaseManager.Reader[1].ToString();
            Int64 logo = 0; //logo = Int64.Parse(reader[2].ToString()); problème de format string à régler
            var championshipId = int.Parse(DatabaseManager.Reader[3].ToString());
            var clubId = int.Parse(DatabaseManager.Reader[4].ToString());

            return new Team(id, name, logo, championshipId, clubId);
        }
    }
}
