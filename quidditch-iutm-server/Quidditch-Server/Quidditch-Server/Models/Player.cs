using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Models
{
    public class Player
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public int Number { get; private set; }
        public Team Team { get; private set; }

        public Player(string firstName, string lastName, DateTime dateOfBirth, int number, Team team = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Number = number;
            this.Team = team;
        }
    }
}
