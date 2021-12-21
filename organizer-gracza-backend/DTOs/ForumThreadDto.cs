using System;
using System.Collections.Generic;

namespace organizer_gracza_backend.DTOs
{
    public class ForumThreadDto
    {
        public int ForumThreadId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? ThreadDate { get; set; }
        
        public ICollection<ForumPostDto> ForumPosts{get; set; }
        
        public int? UserId { get; set; }
        public UserDto User { get; set; }
        
        public int? GameId { get; set; }
        public GameDto Game { get; set; }
    }
}