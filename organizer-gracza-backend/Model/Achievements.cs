using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class Achievements
    {
        [Key]
        public int AchievementsId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Details { get; set; }
        
        public ICollection<UserAchievement> UserAchievements { get; set; }
    }
}