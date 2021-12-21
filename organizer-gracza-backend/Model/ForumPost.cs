using System;
using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class ForumPost
    {
        [Key]
        public int ForumPostId { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
        
        public int ForumThreadId { get; set; }
        public ForumThread ForumThread { get; set; }
    }
}