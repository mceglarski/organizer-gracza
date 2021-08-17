using System;
using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class ForumPost
    {
        [Key]
        public int IdForumPost { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public User User { get; set; }
        public ForumThread ForumThread { get; set; }
    }
}