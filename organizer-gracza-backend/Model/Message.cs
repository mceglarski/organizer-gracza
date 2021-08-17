using System;
using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class Message
    {
        [Key]
        public int IdMessage { get; set; }
        public string Content { get; set; }
        public DateTime MessageDate { get; set; }
        public User User { get; set; }
        public Chat Chat { get; set; }
    }
}