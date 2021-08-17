using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class Chat
    {
        [Key]
        public int IdChat { get; set; }
        public string Name { get; set; }
    }
}