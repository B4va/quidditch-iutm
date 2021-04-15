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
            List<Match> list = new List<Match>();

            var connection = DatabaseManager.GetConnection();

            //Opens the connection to the database
            connection.Open();

            //Defines a query for the connected database
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM match", connection);

            //Execute the query
            NpgsqlDataReader reader = command.ExecuteReader();

            //Read result of the query
            while (reader.Read())
            {
                //Convert the result of each column to a C# supported type
                var id = int.Parse(reader[0].ToString());
                var status = reader[1].ToString();
                int homeTeamId = int.Parse(reader[2].ToString());
                int visitorTeamId = int.Parse(reader[3].ToString());
                var date = reader[4].ToString();
                var time = reader[5].ToString();

                //Create the Championship object using the data and add it to the list
                list.Add(new Match(id, status, homeTeamId, visitorTeamId, date, time));
            }

            //return the list of all championships
            return list;
        }

        public static Match GetById(int id)
        {
            List<Match> matches = GetAllMatches();

            foreach (Match m in matches)
            {
                if (m.Id == id)
                {
                    return m;
                }
            }

            return null;
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
