using Quidditch_Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; } //Should be of type DateTime
        public int Number { get; set; }
        public Club Club { get; set; }


        private DatabaseManager DBManager;

        public Player()
        {
            DBManager = new DatabaseManager();
        }

        public Player(int id, string firstName, string lastName, string dateOfBirth, int number, int club)
        {
            DBManager = new DatabaseManager();

            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Number = number;
            this.Club = new Club().GetById(club);
        }

        public List<Player> GetAllPlayers()
        {
            return DBManager.QueryListResult<Player>("SELECT * FROM player", () =>
            {
                return ReaderToPlayerObject();
            });
        }

        public Player GetById(int id)
        {
            return DBManager.QuerySingleObjectResult<Player>(
                string.Format("SELECT * FROM player WHERE id = '{0}'", id),
                () => ReaderToPlayerObject());
        }

        private Player ReaderToPlayerObject()
        {
            var id = int.Parse(DBManager.Reader[0].ToString());
            var firstname = DBManager.Reader[1].ToString();
            var lastname = DBManager.Reader[2].ToString();
            var dateOfBirth = DBManager.Reader[3].ToString();
            var number = int.Parse(DBManager.Reader[4].ToString());
            var clubId = int.Parse(DBManager.Reader[5].ToString());

            return new Player(id, firstname, lastname, dateOfBirth, number, clubId);
        }
    }
}
