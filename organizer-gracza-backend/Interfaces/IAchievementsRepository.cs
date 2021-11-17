using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IAchievementsRepository
    {
        Task<Achievements> GetAchievementByIdAsync(int achievementsId);
        Task<IEnumerable<Achievements>> GetAchievementsByUserId(int userId);
        Task<IEnumerable<Achievements>> GetAchievementsAsync();
        void AddAchievement(Achievements achievement);
        void DeleteAchievement(Achievements achievement);
        Task<bool> SaveAllAsync();       
        void UpdateAchievement(Achievements achievement);
    }
}