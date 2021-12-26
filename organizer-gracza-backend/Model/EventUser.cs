using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace organizer_gracza_backend.Model
{
    public class EventUser
    {
        [Key]
        public int EventUserId { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [MaxLength(100)]
        public string EventType { get; set; }
        public double? WinnerPrize { get; set; }
        [MaxLength(100)]
        public string EventOrganiser { get; set; }
        [MaxLength(200)]
        public string PhotoUrl { get; set; }
        public int? GameId { get; set; }
        public Game Game { get; set; }
        public ICollection<EventUserRegistration> EventUserRegistration { get; set; }

        public int? EventUserResultId { get; set; }
        public EventUserResult EventUserResult { get; set; }
    }
}