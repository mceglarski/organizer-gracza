using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.DTOs
{
    public class EventUserRegistrationDto
    {
        public int EventUserRegistrationId { get; set; }
        public int UserId { get; set; }
        public int EventUserId { get; set; }
    }
}