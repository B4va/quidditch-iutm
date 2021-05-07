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

        private DatabaseManager DBManager;

        public Club()
        {
            DBManager = new DatabaseManager();
        }

        public Club(int id, string name)
        {
            DBManager = new DatabaseManager();
            this.Id = id;
            this.Name = name;
        }

        public List<Club> GetAllClubs()
        {
            return DBManager.QueryListResult<Club>("SELECT * FROM club", () =>
            {
                return ReaderToClubObject();
            });
        }

        public Club GetById(int id)
        {
            return DBManager.QuerySingleObjectResult<Club>(
                string.Format("SELECT * FROM club WHERE id = '{0}'", id),
                () => ReaderToClubObject());
        }

        private Club ReaderToClubObject()
        {
            var id = int.Parse(DBManager.Reader[0].ToString());
            var name = DBManager.Reader[1].ToString();

            return new Club(id, name);
        }
    }
}
