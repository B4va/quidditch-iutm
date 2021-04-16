using Npgsql;
using Quidditch_Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Models
{
    public class Championship
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }


        public Championship(int id, int year, string name)
        {
            this.Id = id;
            this.Year = year;
            this.Name = name;
        }

        public static List<Championship> GetAllChampionships()
        {
            List<Championship> list = new List<Championship>();

            var connection = DatabaseManager.GetConnection();

            //Opens the connection to the database
            connection.Open();

            //Defines a query for the connected database
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM championship", connection);

            //Execute the query
            NpgsqlDataReader reader = command.ExecuteReader();

            //Read result of the query
            while(reader.Read())
            {
                //Convert the result of each column to a C# supported type
                var id = int.Parse(reader[0].ToString());
                var year = int.Parse(reader[1].ToString());
                var name = reader[2].ToString();
            
                //Create the Championship object using the data and add it to the list
                list.Add(new Championship(id, year, name));
            }

            //return the list of all championships
            return list;
        }

        public static Championship GetLast()
        {
            List<Championship> championships = GetAllChampionships();

            int currentYear = DateTime.Now.Year;
            Championship lastChampionship = championships.FirstOrDefault();
            foreach (Championship c in championships)
            {
                if (c.Year < currentYear && c.Year > lastChampionship.Year)
                {
                    lastChampionship = c;
                }
            }

            if (lastChampionship.Equals(null) || lastChampionship.Year >= currentYear)
            {
                return null;
            }

            return lastChampionship;
        }

        public static Championship GetById(int id)
        {
            List<Championship> championships = GetAllChampionships();

            foreach (Championship c in championships)
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
