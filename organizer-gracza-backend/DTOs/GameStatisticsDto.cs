namespace organizer_gracza_backend.DTOs
{
    public class GameStatisticsDto
    {
        public int GameStatisticsId { get; set; }
        public int? WonGames { get; set; }
        public int? LostGames { get; set; }
        
        public int? GameId { get; set; }
        public int? UserId { get; set; }
    }
}