using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IEventUserRepository
    {
        Task<EventUser> GetEventUserAsync(int eventId);
        Task<IEnumerable<EventUser>> GetEventsUserAsync();
        void AddEventUser(EventUser specifiedEvent);
        void DeleteEventUser(EventUser specifiedEvent);
        Task<bool> SaveAllAsync();       
        void UpdateEventUser(EventUser specifiedEvent);
    }
}