using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using organizer_gracza_backend.DTOs;

namespace organizer_gracza_backend.Model
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; }
        
        public string PhotoUrl { get; set; }
        public ICollection<EventTeamRegistration> EventTeamRegistration { get; set; }
        public ICollection<TeamUser> TeamUser { get; set; }
    }
}