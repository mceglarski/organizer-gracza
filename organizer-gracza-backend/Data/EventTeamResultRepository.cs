using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class EventTeamResultRepository : IEventTeamResultRepository
    {
        private readonly DataContext _context;

        public EventTeamResultRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EventTeamResult> GetEventTeamResultById(int eventTeamResultId)
        {
            return await _context.EventTeamResult
                .Include(a => a.EventTeam)
                .Include(a => a.Team)
                .SingleOrDefaultAsync(x => x.EventTeamResultId == eventTeamResultId);
        }

        public async Task<IEnumerable<EventTeamResult>> GetEventTeamResults()
        {
            return await _context.EventTeamResult
                .Include(a => a.EventTeam)
                .Include(a => a.Team)
                .ToListAsync();
        }

        public void AddEventTeamResult(EventTeamResult eventTeamResult)
        {
            _context.EventTeamResult.Add(eventTeamResult);
        }

        public void DeleteEventTeamResult(EventTeamResult eventTeamResult)
        {
            _context.EventTeamResult.Remove(eventTeamResult);
        }

        public void UpdateEventTeamResult(EventTeamResult eventTeamResult)
        {
            _context.Attach(eventTeamResult);
            _context.Entry(eventTeamResult).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}