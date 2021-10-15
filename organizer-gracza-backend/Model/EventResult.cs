using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class EventResult
    {
        [Key]
        public int EventResultId { get; set; }
        public string WinnerName { get; set; }
        // public Event Event { get; set; }
    }
}