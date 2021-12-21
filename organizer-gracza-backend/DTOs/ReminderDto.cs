using System;

namespace organizer_gracza_backend.DTOs
{
    public class ReminderDto
    {
        public int ReminderId { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        
        public UserDto User { get; set; }
        public int? UserId { get; set; }
    }
}