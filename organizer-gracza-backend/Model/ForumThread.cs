using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace organizer_gracza_backend.Model
{
    public class ForumThread
    {
        [Key]
        public int ForumThreadId { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(2000)]
        public string Content { get; set; }
        public DateTime ThreadDate { get; set; }
        
        public ICollection<ForumPost> ForumPosts{get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
        
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}