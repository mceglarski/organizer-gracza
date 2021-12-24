using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class UserAchievement
    {
        [Key]
        public int UserAchievementId { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? AchievementsId { get; set; }
        public Achievements Achievements { get; set; }
    }
}