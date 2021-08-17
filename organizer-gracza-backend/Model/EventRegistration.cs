using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class EventRegistration
    {
        [Key]
        public int IdEventRegistration { get; set; }
        public User User { get; set; }
        public Team Team { get; set; }
        public Event Event { get; set; }
    }
}