namespace organizer_gracza_backend.Model
{
    public class GameStatistics
    {
        public int IdGameStatistics { get; set; }
        public int WonGames { get; set; }
        public int LostGames { get; set; }
        public Game Game { get; set; }
    }
}