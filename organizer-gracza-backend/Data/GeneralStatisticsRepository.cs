using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class GeneralStatisticsRepository : IGeneralStatisticsRepository
    {
        private readonly DataContext _context;
        public GeneralStatisticsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<GeneralStatistics> GetGeneralStatisticsByIdAsync(int generalStatisticId)
        {
            return await _context.GeneralStatistics
                .Include(u => u.User)
                .SingleOrDefaultAsync(x => x.GeneralStatisticsId == generalStatisticId);
        }

        public async Task<IEnumerable<GeneralStatistics>> GetGeneralStatisticsAsync()
        {
            return await _context.GeneralStatistics
                .Include(u => u.User)
                .ToListAsync();
        }

        public void AddGeneralStatistics(GeneralStatistics generalStatistics)
        {
            _context.GeneralStatistics.Add(generalStatistics);
        }

        public void DeleteGeneralStatistics(GeneralStatistics generalStatistics)
        {
            _context.GeneralStatistics.Remove(generalStatistics);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateGeneralStatistics(GeneralStatistics generalStatistics)
        {
            _context.Attach(generalStatistics);
            _context.Entry(generalStatistics).State = EntityState.Modified;
        }
    }
}