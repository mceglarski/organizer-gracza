using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace organizer_gracza_backend.Model
{
    public class EventTeamResult
    {
        [Key]
        public int EventTeamResultId { get; set; }
        
        public int? TeamId { get; set; }
        public Team Team { get; set; }
        
        public int? EventTeamId { get; set; }
        public EventTeam EventTeam { get; set; }
        
    }
}