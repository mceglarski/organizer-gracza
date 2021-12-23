using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IUserAchievementRepository
    {
        Task<UserAchievement> GetUserAchievementByIdAsync(int userAchievementsId);
        Task<IEnumerable<UserAchievement>> GetUserAchievementsForUserAsync(int userId);
        Task<IEnumerable<UserAchievement>> GetUserAchievementsForAchievementAsync(int achievementId);
        Task<UserAchievement> GetUserAchievementsForUserAndAchievementAsync(int userId, int achievementId);
        Task<IEnumerable<UserAchievement>> GetUserAchievementsAsync();
        void AddUserAchievement(UserAchievement userAchievement);
        void DeleteUserAchievement(UserAchievement userAchievement);
        Task<bool> SaveAllAsync();       
        void UpdateUserAchievement(UserAchievement userAchievement);
    }
}