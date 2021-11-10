using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class GameStatisticsRepository : IGameStatisticsRepository
    {
        private readonly DataContext _context;
        public GameStatisticsRepository(DataContext context)
        {
            _context = context;
        }
        
        public  async Task<GameStatistics> GetGameStatisticsByIdAsync(int gameStatisticsId)
        {
            return await _context.GameStatistics
                .Include(u => u.User)
                .Include(g => g.Game)
                .SingleOrDefaultAsync(x => x.GameStatisticsId == gameStatisticsId);
        }

        public async Task<IEnumerable<GameStatistics>> GetGameStatisticsAsync()
        {
            return await _context.GameStatistics
                .Include(u => u.User)
                .Include(g => g.Game)
                .ToListAsync();
        }

        public void AddGameStatistics(GameStatistics gameStatistics)
        {
            _context.GameStatistics.Add(gameStatistics);
        }

        public void DeleteGameStatistics(GameStatistics gameStatistics)
        {
            _context.GameStatistics.Remove(gameStatistics);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateGameStatistics(GameStatistics gameStatistics)
        {
            _context.Attach(gameStatistics);
            _context.Entry(gameStatistics).State = EntityState.Modified;
        }
    }
}