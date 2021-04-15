using Npgsql;
using Quidditch_Server.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Club(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public static List<Club> GetAllClubs()
        {
            List<Club> list = new List<Club>();

            var connection = DatabaseManager.GetConnection();

            //Opens the connection to the database
            connection.Open();

            //Defines a query for the connected database
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM club", connection);

            //Execute the query
            NpgsqlDataReader reader = command.ExecuteReader();

            //Read result of the query
            while (reader.Read())
            {
                //Convert the result of each column to a C# supported type
                var id = int.Parse(reader[0].ToString());
                var name = reader[1].ToString();

                //Create the Championship object using the data and add it to the list
                list.Add(new Club(id, name));
            }

            //return the list of all championships
            return list;
        }

        public static Club GetById(int id)
        {
            List<Club> clubs = GetAllClubs();

            foreach (Club c in clubs)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }

            return null;
        }
    }
}
