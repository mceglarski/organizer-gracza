using System;
using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class ForumThread
    {
        [Key]
        public int ForumThreadId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime ThreadDate { get; set; }
        public User User { get; set; }
    }
}