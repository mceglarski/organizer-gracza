using System;

namespace organizer_gracza_backend.Model
{
    public class Reminder
    {
        public int IdRemind { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime ReminderDate { get; set; }
        public User User { get; set; }
    }
}