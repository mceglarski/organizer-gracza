using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.DTOs
{
    public class UserGameDto
    {
        public int? UserGameId { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
    }
}