using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.DTOs
{
    public class UserAchievementDto
    {
        public int UserAchievementId { get; set; }
        public int? UserId { get; set; }
        public UserDto User { get; set; }
        public int? AchievementsId { get; set; }
        public AchievementsDto Achievements { get; set; }
    }
}