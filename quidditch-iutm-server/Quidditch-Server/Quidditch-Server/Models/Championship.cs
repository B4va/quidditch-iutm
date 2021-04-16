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
            return DatabaseManager.QueryListResult<Championship>(
                "SELECT * FROM championship",
                () => ReaderToChampionshipObject());
        }

        public static Championship GetById(int id)
        {
            return DatabaseManager.QuerySingleObjectResult<Championship>(
                string.Format("SELECT * FROM championship WHERE id = '{0}'", id),
                () => ReaderToChampionshipObject());
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

        private static Championship ReaderToChampionshipObject()
        {
            var id = int.Parse(DatabaseManager.Reader[0].ToString());
            var year = int.Parse(DatabaseManager.Reader[1].ToString());
            var name = DatabaseManager.Reader[2].ToString();

            return new Championship(id, year, name);
        }
    }
}
