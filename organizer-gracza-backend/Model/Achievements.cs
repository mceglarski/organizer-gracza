using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class Achievements
    {
        [Key]
        public int AchievementsId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
    }
}