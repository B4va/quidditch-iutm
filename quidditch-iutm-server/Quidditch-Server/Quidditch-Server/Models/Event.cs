using Quidditch_Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Match Match { get; set; }
        public Player Player { get; set; }


        private DatabaseManager DBManager;

        public Event()
        {
            DBManager = new DatabaseManager();
        }

        public Event(int id, int time, string description, string type, int match, int player)
        {
            DBManager = new DatabaseManager();

            this.Id = id;
            this.Time = time;
            this.Description = description;
            this.Type = type;
            this.Match = new Match().GetById(match);
            this.Player = new Player().GetById(player);
        }

        public List<Event> GetAllEvents()
        {
            return DBManager.QueryListResult<Event>("SELECT * FROM event", () =>
            {
                return ReaderToEventObject();
            });
        }

        public Event GetById(int id)
        {
            return DBManager.QuerySingleObjectResult<Event>(
                string.Format("SELECT * FROM event WHERE id = '{0}'", id),
                () => ReaderToEventObject());
        }

        public List<Event> GetMatchEvents(int matchId)
        {
            return DBManager.QueryListResult<Event>(
                "SELECT * FROM event " +
                $"WHERE match_id =  {matchId}"
                , () =>
            {
                return ReaderToEventObject();
            });
        }

        private Event ReaderToEventObject()
        {
            var id = int.Parse(DBManager.Reader[0].ToString());
            var time = int.Parse(DBManager.Reader[1].ToString());
            var description = DBManager.Reader[2].ToString();
            var type = DBManager.Reader[3].ToString();
            var match = int.Parse(DBManager.Reader[4].ToString());
            var player = int.Parse(DBManager.Reader[5].ToString());

            return new Event(id, time, description, type, match, player);
        }
    }
}
