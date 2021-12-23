using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class AchievementsRepository : IAchievementsRepository
    {
        private readonly DataContext _context;

        public AchievementsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Achievements> GetAchievementByIdAsync(int achievementsId)
        {
            return await _context.Achievements
                .Include(u => u.UserAchievements)
                .SingleOrDefaultAsync(x => x.AchievementsId == achievementsId);
        }
        

        public async Task<IEnumerable<Achievements>> GetAchievementsAsync()
        {
            return await _context.Achievements
                .Include(u => u.UserAchievements)
                .ToListAsync();
        }

        public void AddAchievement(Achievements achievement)
        {
            _context.Achievements.Add(achievement);
        }

        public void DeleteAchievement(Achievements achievement)
        {
            _context.Achievements.Remove(achievement);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateAchievement(Achievements achievement)
        {
            _context.Attach(achievement);
            _context.Entry(achievement).State = EntityState.Modified;
        }
    }
}