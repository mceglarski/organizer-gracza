using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class UserAchievementRepository : IUserAchievementRepository
    {
        private readonly DataContext _context;

        public UserAchievementRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<UserAchievement> GetUserAchievementByIdAsync(int userAchievementsId)
        {
            return await _context.UserAchievements
                .Include(u => u.Achievements)
                .Include(u => u.User)
                .SingleOrDefaultAsync(x => x.UserAchievementId == userAchievementsId);
        }

        public async Task<IEnumerable<UserAchievement>> GetUserAchievementsForUserAsync(int userId)
        {
            return await _context.UserAchievements
                .Include(u => u.Achievements)
                .Include(u => u.User)
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserAchievement>> GetUserAchievementsForAchievementAsync(int achievementId)
        {
            return await _context.UserAchievements
                .Include(u => u.Achievements)
                .Include(u => u.User)
                .Where(x => x.AchievementsId == achievementId)
                .ToListAsync();
        }

        public async Task<UserAchievement> GetUserAchievementsForUserAndAchievementAsync(int userId, int achievementId)
        {
            return await _context.UserAchievements
                .Include(u => u.Achievements)
                .Include(u => u.User)
                .Where(x => x.UserId == userId)
                .SingleOrDefaultAsync(x => x.AchievementsId == achievementId);
        }

        public async Task<IEnumerable<UserAchievement>> GetUserAchievementsAsync()
        {
            return await _context.UserAchievements
                .Include(u => u.Achievements)
                .Include(u => u.User)
                .ToListAsync();
        }

        public void AddUserAchievement(UserAchievement userAchievement)
        {
            _context.UserAchievements.Add(userAchievement);
        }

        public void DeleteUserAchievement(UserAchievement userAchievement)
        {
            _context.UserAchievements.Remove(userAchievement);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateUserAchievement(UserAchievement userAchievement)
        {
            _context.Attach(userAchievement);
            _context.Entry(userAchievement).State = EntityState.Modified;
        }
    }
}