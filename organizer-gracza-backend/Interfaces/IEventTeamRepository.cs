using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IEventTeamRepository
    {
        Task<EventTeam> GetEventTeamAsync(int eventId);
        Task<IEnumerable<EventTeam>> GetEventsTeamAsync();
        void AddEventTeam(EventTeam specifiedEvent);
        void DeleteEventTeam(EventTeam specifiedEvent);
        Task<bool> SaveAllAsync();       
        void UpdateEventTeam(EventTeam specifiedEvent);
    }
}