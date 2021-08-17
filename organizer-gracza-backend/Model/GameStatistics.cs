using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class GameStatistics
    {
        [Key]
        public int IdGameStatistics { get; set; }
        public int WonGames { get; set; }
        public int LostGames { get; set; }
        public Game Game { get; set; }
    }
}