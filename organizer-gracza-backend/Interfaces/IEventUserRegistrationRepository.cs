using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IEventUserRegistrationRepository
    {
        Task<EventUserRegistration> GetEventUserRegistrationAsync(int eventUserRegistrationId);
        Task<IEnumerable<EventUserRegistration>> GetEventRegistrationAsync(int eventUserId);

        Task<IEnumerable<EventUserRegistration>> GetEventsUserRegistrationAsync();
        void AddEventUserRegistration(EventUserRegistration eventUserRegistration);
        void DeleteEventUserRegistration(EventUserRegistration eventUserRegistration);
        Task<bool> SaveAllAsync();    
    }
}