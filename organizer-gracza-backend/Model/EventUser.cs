using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class EventUser
    {
        [Key]
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
        public Game Game { get; set; }
        public ICollection<EventUserRegistration> EventUserRegistration { get; set; }
    }
}