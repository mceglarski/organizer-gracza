using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class UserGame
    {
        [Key]
        public int UserGameId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}