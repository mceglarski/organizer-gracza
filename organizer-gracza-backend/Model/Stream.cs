namespace organizer_gracza_backend.Model
{
    public class Stream
    {
        public int IdStream { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public Game Game { get; set; }
    }
}