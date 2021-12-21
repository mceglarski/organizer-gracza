using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class EventResult
    {
        [Key]
        public int EventResultId { get; set; }
        public string WinnerName { get; set; }
        
        public int? EventTeamRegistrationId { get; set; }
        public EventTeamRegistration EventTeamRegistration { get; set; }
        
        public int? EventUserRegistrationId { get; set; }
        public EventUserRegistration EventUserRegistration { get; set; }
    }
}