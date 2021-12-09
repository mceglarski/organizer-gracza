using System;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.DTOs
{
    public class ArticlesDto
    {
        public int ArticlesId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string PhotoUrl { get; set; }
        
        public int? UserId { get; set; }
        public UserDto User { get; set; }
    }
}