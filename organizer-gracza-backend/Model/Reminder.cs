using System;
using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class Reminder
    {
        [Key]
        public int ReminderId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime ReminderDate { get; set; }
        public User User { get; set; }
    }
}