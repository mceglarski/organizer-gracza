using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class EventUserRepository : IEventUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EventUserRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<EventUser> GetEventUserAsync(int eventId)
        {
            return await _context.EventUser
                .Include(e => e.EventUserRegistration)
                .Include(g => g.Game)
                .SingleOrDefaultAsync(x => x.EventUserId == eventId);
        }

        public async Task<EventUser> GetEventUserByNameAsync(string name)
        {
            return await _context.EventUser
                .Include(e => e.EventUserRegistration)
                .Include(g => g.Game)
                .SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<EventUser>> GetEventsUserAsync()
        {
            return await _context.EventUser
                .Include(e => e.EventUserRegistration)
                .Include(g => g.Game)
                .ToListAsync();
        }

        public void AddEventUser(EventUser specifiedEvent)
        {
            _context.EventUser.Add(specifiedEvent);
        }

        public void DeleteEventUser(EventUser specifiedEvent)
        {
            _context.EventUser.Remove(specifiedEvent);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateEventUser(EventUser specifiedEvent)
        {
            _context.Attach(specifiedEvent);
            _context.Entry(specifiedEvent).State = EntityState.Modified;
        }
    }
}