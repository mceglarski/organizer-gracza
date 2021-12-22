using System;
using System.Collections.Generic;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.DTOs
{
    public class EventTeamDto
    {
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
        public GameDto Game { get; set; }
        public ICollection<EventTeamRegistrationDto> EventTeamRegistration { get; set; }
        public int? EventResultId { get; set; }
        public EventTeamResultDto EventTeamResult { get; set; }
    }
}