using System;
using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        [MinLength(2), MaxLength(20)]
        public string SenderUsername { get; set; }
        public User Sender { get; set; }
        public int RecipientId { get; set; }
        [MinLength(2), MaxLength(20)]
        public string RecipientUsername { get; set; }
        public User Recipient { get; set; }
        [MaxLength(1000)]
        public string Content { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime MessageSent { get; set; } = DateTime.UtcNow;
        public bool SenderDeleted { get; set; }
        public bool RecipientDeleted { get; set; }
    }
}