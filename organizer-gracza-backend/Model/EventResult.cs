namespace organizer_gracza_backend.Model
{
    public class EventResult
    {
        public int IdEventResult { get; set; }
        public string WinnerName { get; set; }
        public Event Event { get; set; }
    }
}