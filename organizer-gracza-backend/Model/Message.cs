using System;

namespace organizer_gracza_backend.Model
{
    public class Message
    {
        public int IdMessage { get; set; }
        public string Content { get; set; }
        public DateTime MessageDate { get; set; }
        public User User { get; set; }
        public Chat Chat { get; set; }
    }
}