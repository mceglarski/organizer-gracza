using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.DTOs
{
    public class EventTeamRegistrationDto
    {
        public int EventTeamRegistrationId { get; set; }
        public int TeamId { get; set; }
        public int EventTeamId { get; set; }
    }
}