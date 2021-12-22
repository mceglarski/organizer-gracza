using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace organizer_gracza_backend.Model
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<EventTeam> EventTeam { get; set; }
        public ICollection<EventUser> EventUser { get; set; }
        public ICollection<GameStatistics> GameStatistics { get; set; }
        
        public ICollection<ForumThread> ForumThread { get; set; }
        
        public ICollection<UserGame> UserGames { get; set; }

    }
}