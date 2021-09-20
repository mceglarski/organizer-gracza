using System.ComponentModel.DataAnnotations.Schema;

namespace organizer_gracza_backend.Model
{
    [Table("Photos")]
    public class Photo
    {
        public int PhotoId { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}