using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class EventUserRegistrationRepository : IEventUserRegistrationRepository
    {
        private readonly DataContext _context;

        public EventUserRegistrationRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<EventUserRegistration> GetEventUserRegistrationAsync(int eventUserRegistrationId)
        {
            return await _context.EventUserRegistration
                .Include(e => e.EventUser)
                .Include(u => u.User)
                .SingleOrDefaultAsync(x => x.EventUserRegistrationId == eventUserRegistrationId);
        }

        public async Task<IEnumerable<EventUserRegistration>> GetEventRegistrationAsync(int eventUserId)
        {
            return await _context.EventUserRegistration
                .Include(e => e.EventUser)
                .Include(u => u.User)
                .Where(x => x.EventUserId == eventUserId)
                .ToListAsync();
        }

        public async Task<EventUserRegistration> GetEventUserRegistrationForUserAsync(int eventUserId, int userId)
        {
            return await _context.EventUserRegistration
                .Include(e => e.EventUser)
                .Include(u => u.User)
                .Where(x => x.EventUserId == eventUserId)
                .SingleOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<IEnumerable<EventUserRegistration>> GetEventsUserRegistrationAsync()
        {
            return await _context.EventUserRegistration
                .Include(e => e.EventUser)
                .Include(u => u.User)
                .ToListAsync();
        }

        public void AddEventUserRegistration(EventUserRegistration eventUserRegistration)
        {
            _context.EventUserRegistration.Add(eventUserRegistration);
        }

        public void DeleteEventUserRegistration(EventUserRegistration eventUserRegistration)
        {
            _context.EventUserRegistration.Remove(eventUserRegistration);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}