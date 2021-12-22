using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace organizer_gracza_backend.Model
{
    public class EventTeam
    {
        [Key]
        public int EventTeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string EventType { get; set; }
        public double? WinnerPrize { get; set; }
        public string EventOrganiser { get; set; }
        public string PhotoUrl { get; set; }
        public int? GameId { get; set; }
        public Game Game { get; set; }
        public ICollection<EventTeamRegistration> EventTeamRegistration { get; set; }
        
        public int? EventTeamResultId { get; set; }
        
        public EventTeamResult EventTeamResult { get; set; }
    }
}