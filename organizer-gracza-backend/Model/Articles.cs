using System;

namespace organizer_gracza_backend.Model
{
    public class Articles
    {
        public int IdArticles { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        public User User { get; set; }
    }
}