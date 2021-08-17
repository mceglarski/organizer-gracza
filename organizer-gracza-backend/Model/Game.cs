using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class Game
    {
        [Key]
        public int IdGame { get; set; }
        public string Title { get; set; }
    }
}