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
            List<Team> list = new List<Team>();

            var connection = DatabaseManager.GetConnection();

            //Opens the connection to the database
            connection.Open();

            //Defines a query for the connected database
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM team", connection);

            //Execute the query
            NpgsqlDataReader reader = command.ExecuteReader();

            //Read result of the query
            while (reader.Read())
            {
                //Convert the result of each column to a C# supported type
                var id = int.Parse(reader[0].ToString());
                var name = reader[1].ToString();
                //logo = Int64.Parse(reader[2].ToString()); problème de format string a régler
                Int64 logo = 0;
                var championshipId = int.Parse(reader[3].ToString());
                var clubId = int.Parse(reader[4].ToString());

                //Create the Championship object using the data and add it to the list
                list.Add(new Team(id, name, logo, championshipId, clubId));
            }

            //return the list of all championships
            return list;
        }

        public static Team GetById(int id)
        {
            List<Team> teams = Team.GetAllTeams();

            foreach (Team t in teams)
            {
                if (t.Id == id)
                {
                    return t;
                }
            }

            return null;
        }
    }
}
