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
            return DatabaseManager.QueryListResult<Club>("SELECT * FROM club", () =>
            {
                return ReaderToClubObject();
            });
        }

        public static Club GetById(int id)
        {
            return DatabaseManager.QuerySingleObjectResult<Club>(
                string.Format("SELECT * FROM club WHERE id = '{0}'", id),
                () => ReaderToClubObject());
        }

        private static Club ReaderToClubObject()
        {
            var id = int.Parse(DatabaseManager.Reader[0].ToString());
            var name = DatabaseManager.Reader[1].ToString();

            return new Club(id, name);
        }
    }
}
