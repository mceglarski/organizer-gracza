using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IEventTeamRegistrationRepository
    {
        Task<EventTeamRegistration> GetEventTeamRegistrationAsync(int eventTeamRegistrationId);
        Task<IEnumerable<EventTeamRegistration>> GetEventRegistrationAsync(int eventTeamId);
        Task<IEnumerable<EventTeamRegistration>> GetEventsTeamRegistrationAsync();
        void AddEventTeamRegistration(EventTeamRegistration eventTeamRegistration);
        void DeleteEventTeamRegistration(EventTeamRegistration eventTeamRegistration);
        Task<bool> SaveAllAsync();   
    }
}