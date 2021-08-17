using System;
using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class Event
    {
        [Key]
        public int IdEvent { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventType { get; set; }
    }
}