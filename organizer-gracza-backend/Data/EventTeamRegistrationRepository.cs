using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class EventTeamRegistrationRepository : IEventTeamRegistrationRepository
    {
        private readonly DataContext _context;

        public EventTeamRegistrationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<EventTeamRegistration> GetEventTeamRegistrationAsync(int eventTeamRegistrationId)
        {
            return await _context.EventTeamRegistration
                .Include(e => e.EventTeam)
                .Include(t => t.Team)
                .FirstOrDefaultAsync(x => x.EventTeamRegistrationId == eventTeamRegistrationId);
        }

        public async Task<IEnumerable<EventTeamRegistration>> GetEventRegistrationAsync(int eventTeamId)
        {
            return await _context.EventTeamRegistration
                .Include(e => e.EventTeam)
                .Include(t => t.Team)
                .Where(x => x.EventTeamId == eventTeamId)
                .ToListAsync();
        }

        public Task<EventTeamRegistration> GetEventRegistrationForEvent(int eventTeamId, int teamId)
        {
            return _context.EventTeamRegistration
                .Include(e => e.EventTeam)
                .Include(t => t.Team)
                .Where(x => x.EventTeamId == eventTeamId)
                .FirstOrDefaultAsync(a => a.TeamId == teamId);
        }

        public async Task<IEnumerable<EventTeamRegistration>> GetEventsTeamRegistrationAsync()
        {
            return await _context.EventTeamRegistration
                .Include(e => e.EventTeam)
                .Include(t => t.Team)
                .ToListAsync();
        }

        public void AddEventTeamRegistration(EventTeamRegistration eventTeamRegistration)
        {
            _context.EventTeamRegistration.Add(eventTeamRegistration);
        }

        public void DeleteEventTeamRegistration(EventTeamRegistration eventTeamRegistration)
        {
            _context.EventTeamRegistration.Remove(eventTeamRegistration);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}