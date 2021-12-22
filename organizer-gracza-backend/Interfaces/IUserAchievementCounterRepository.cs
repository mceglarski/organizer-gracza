using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IUserAchievementCounterRepository
    {
        Task<UserAchievementCounter> GetUserAchievementCounterByIdAsync(int userAchievementCounterId);
        Task<UserAchievementCounter> GetUserAchievementCounterByUsernameAsync(string username);
        Task<IEnumerable<UserAchievementCounter>> GetUserAchievementsCountersByUserId(int userId);
        Task<UserAchievementCounter> GetUserAchievementCounterByUserId(int userId);
        Task<UserAchievementCounter> GetUserAchievementCounterByIds(int userAchievementCounterId, int userId);
        Task<IEnumerable<UserAchievementCounter>> GetUserAchievementCounterAsync();
        void AddUserAchievementCounter(UserAchievementCounter userAchievementCounter);
        void DeleteUserAchievementCounter(UserAchievementCounter userAchievementCounter);
        Task<bool> SaveAllAsync();       
        void UpdateUserAchievementCounter(UserAchievementCounter userAchievementCounter);
    }
}