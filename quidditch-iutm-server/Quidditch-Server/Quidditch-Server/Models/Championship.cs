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
        public List<Team> Teams { get; set; }

        private DatabaseManager DBManager;
        
        public Championship()
        {
            DBManager = new DatabaseManager();
        }

        public Championship(int id, int year, string name)
        {
            DBManager = new DatabaseManager();

            this.Id = id;
            this.Year = year;
            this.Name = name;
            this.Teams = new List<Team>();
        }

        public List<Championship> GetAllChampionships()
        {
            return DBManager.QueryListResult<Championship>(
                "SELECT * FROM championship",
                () => ReaderToChampionshipObject());
        }

        public Championship GetById(int id)
        {
            return DBManager.QuerySingleObjectResult<Championship>(
                string.Format("SELECT * " +
                              "FROM championship " +
                              "WHERE id = '{0}'",
                              id),
                () => ReaderToChampionshipObject());
        }

        public Championship GetLast()
        {
            int currentYear = DateTime.Now.Year;

            Championship lastChampionship = DBManager.QuerySingleObjectResult<Championship>(
                string.Format("SELECT * " +
                              "FROM championship " +
                              "WHERE championship.year < {0} " +
                              "ORDER BY championship.year DESC " +
                              "LIMIT 1", 
                              currentYear), 
                () => ReaderToChampionshipObject());

            return lastChampionship;
        }

        protected Championship ReaderToChampionshipObject()
        {
            var id = int.Parse(DBManager.Reader[0].ToString());
            var year = int.Parse(DBManager.Reader[1].ToString());
            var name = DBManager.Reader[2].ToString();

            return new Championship(id, year, name);
        }
    }
}
