using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class EventResultRepository : IEventResultRepository
    {
        private readonly DataContext _context;

        public EventResultRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EventResult> GetEventResultById(int eventResultId)
        {
            return await _context.EventResults
                .Include(a => a.EventTeamRegistration)
                .Include(a => a.EventUserRegistration)
                .SingleOrDefaultAsync(x => x.EventResultId == eventResultId);
        }

        public async Task<IEnumerable<EventResult>> GetEventResults()
        {
            return await _context.EventResults
                .Include(a => a.EventTeamRegistration)
                .Include(a => a.EventUserRegistration)
                .ToListAsync();
        }

        public void AddEventResult(EventResult eventResult)
        {
            _context.EventResults.Add(eventResult);
        }

        public void DeleteEventResult(EventResult eventResult)
        {
            _context.EventResults.Remove(eventResult);
        }

        public void UpdateEventResult(EventResult eventResult)
        {
            _context.Attach(eventResult);
            _context.Entry(eventResult).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}