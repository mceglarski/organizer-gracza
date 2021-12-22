using System;

namespace organizer_gracza_backend.DTOs
{
    public class ForumPostDto
    {
        public int ForumPostId { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        
        public int UserId { get; set; }
        
        public int ForumThreadId { get; set; }
    }
}