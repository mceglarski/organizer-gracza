using System;
using System.Collections.Generic;

namespace organizer_gracza_backend.DTOs
{
    public class EventUserDto
    {
        public int EventUserId { get; set; }
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
        public ICollection<EventUserRegistrationDto> EventUserRegistration { get; set; }

        public int? EventUserResultId { get; set; }
        public EventUserResultDto EventUserResult { get; set; }

    }
}