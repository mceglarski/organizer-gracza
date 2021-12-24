using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}