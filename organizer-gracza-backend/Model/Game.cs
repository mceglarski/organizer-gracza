using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string Title { get; set; }
        public ICollection<EventTeam> EventTeam { get; set; }
        public ICollection<EventUser> EventUser { get; set; }
    }
}