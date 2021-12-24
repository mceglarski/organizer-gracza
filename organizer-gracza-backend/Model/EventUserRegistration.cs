using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class EventUserRegistration
    {
        [Key] 
        public int EventUserRegistrationId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int EventUserId { get; set; }
        public EventUser EventUser { get; set; }
    }
}