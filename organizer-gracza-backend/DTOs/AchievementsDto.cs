using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.DTOs
{
    public class AchievementsDto
    {
        public int AchievementsId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string PhotoUrl { get; set; }
        
        public int? UserId { get; set; }
    }
}