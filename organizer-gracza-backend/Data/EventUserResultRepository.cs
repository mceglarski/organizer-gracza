using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class EventUserResultRepository : IEventUserResultRepository
    {
        private readonly DataContext _context;

        public EventUserResultRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<EventUserResult> GetEventUserResultById(int eventUserResultId)
        {
            return await _context.EventUserResult
                .Include(e => e.EventUser)
                .Include(t => t.User)
                .FirstOrDefaultAsync(x => x.EventUserResultId == eventUserResultId);
        }

        public async Task<IEnumerable<EventUserResult>> GetEventUserResults()
        {
            return await _context.EventUserResult
                .Include(e => e.EventUser)
                .Include(t => t.User)
                .ToListAsync();
        }

        public void AddEventUserResult(EventUserResult eventUserResult)
        {
            _context.EventUserResult.Add(eventUserResult);
        }

        public void DeleteEventUserResult(EventUserResult eventUserResult)
        {
            _context.EventUserResult.Remove(eventUserResult);
        }

        public void UpdateEventUserResult(EventUserResult eventUserResult)
        {
            _context.Attach(eventUserResult);
            _context.Entry(eventUserResult).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}