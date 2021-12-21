using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class UserAchievementCounterRepository : IUserAchievementCounterRepository
    {
        private readonly DataContext _context;

        public UserAchievementCounterRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<UserAchievementCounter> GetUserAchievementCounterByIdAsync(int userAchievementCounterId)
        {
            return await _context.UserAchievementCounters
                .Include(u => u.User)
                .FirstOrDefaultAsync(x => x.UserAchievementCounterId == userAchievementCounterId);
        }

        public async Task<UserAchievementCounter> GetUserAchievementCounterByUsernameAsync(string username)
        {
            return await _context.UserAchievementCounters
                .Include(u => u.User)
                .FirstOrDefaultAsync(u => u.User.UserName == username);
        }

        public async Task<IEnumerable<UserAchievementCounter>> GetUserAchievementsCountersByUserId(int userId)
        {
            return await _context.UserAchievementCounters
                .Include(u => u.User)
                .Where(u => u.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserAchievementCounter> GetUserAchievementCounterByUserId(int userId)
        {
            return await _context.UserAchievementCounters
                .Include(u => u.User)
                .SingleOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<UserAchievementCounter> GetUserAchievementCounterByIds(int userAchievementCounterId, int userId)
        {
            return await _context.UserAchievementCounters
                .Include(u => u.User)
                .Where(u => u.UserId == userId)
                .FirstOrDefaultAsync(x => x.UserAchievementCounterId == userAchievementCounterId);
        }


        public async Task<IEnumerable<UserAchievementCounter>> GetUserAchievementCounterAsync()
        {
            return await _context.UserAchievementCounters
                .Include(u => u.User)
                .ToListAsync();
        }

        public void AddUserAchievementCounter(UserAchievementCounter userAchievementCounter)
        {
            _context.UserAchievementCounters.Add(userAchievementCounter);
        }

        public void DeleteUserAchievementCounter(UserAchievementCounter userAchievementCounter)
        {
            _context.UserAchievementCounters.Remove(userAchievementCounter);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateUserAchievementCounter(UserAchievementCounter userAchievementCounter)
        {
            _context.Attach(userAchievementCounter);
            _context.Entry(userAchievementCounter).State = EntityState.Modified;
        }
    }
}