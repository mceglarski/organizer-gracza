using System;
using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class Articles
    {
        [Key]
        public int ArticlesId { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(10000)]
        public string Content { get; set; }
        public DateTime? PublicationDate { get; set; }
        [MaxLength(200)]
        public string PhotoUrl { get; set; }
        
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}