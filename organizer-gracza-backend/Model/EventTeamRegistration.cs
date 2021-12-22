using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class EventTeamRegistration
    {
        [Key] 
        public int EventTeamRegistrationId { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int EventTeamId { get; set; }
        public EventTeam EventTeam { get; set; }
        
        public int? EventResultId { get; set; }
        
        public EventResult EventResult { get; set; }
    }
}