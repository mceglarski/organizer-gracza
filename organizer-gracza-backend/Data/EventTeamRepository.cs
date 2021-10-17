using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class EventTeamRepository : IEventTeamRepository
    {
        private readonly DataContext _context;
        public EventTeamRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EventTeam> GetEventTeamAsync(int eventId)
        {
            return await _context.EventTeam
                .Include(e => e.EventTeamRegistration)
                .Include(g => g.Game)
                .FirstOrDefaultAsync(x => x.EventTeamId == eventId);
        }

        public async Task<EventTeam> GetEventTeamByNameAsync(string name)
        {
            return await _context.EventTeam
                .Include(e => e.EventTeamRegistration)
                .Include(g => g.Game)
                .FirstOrDefaultAsync(x => x.Name == name);        
        }

        public async Task<IEnumerable<EventTeam>> GetEventsTeamAsync()
        {
            return await _context.EventTeam
                .Include(e => e.EventTeamRegistration)
                .Include(g => g.Game)
                .ToListAsync();
        }

        public void AddEventTeam(EventTeam specifiedEvent)
        {
            _context.EventTeam.Add(specifiedEvent);
        }

        public void DeleteEventTeam(EventTeam specifiedEvent)
        {
            _context.EventTeam.Remove(specifiedEvent);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateEventTeam(EventTeam specifiedEvent)
        {
            _context.Attach(specifiedEvent);
            _context.Entry(specifiedEvent).State = EntityState.Modified;
        }
    }
}