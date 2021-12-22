using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IEventUserResultRepository
    {
        Task<EventUserResult> GetEventUserResultById(int eventUserResultId);
        Task<IEnumerable<EventUserResult>> GetEventUserResults();
        void AddEventUserResult(EventUserResult eventUserResult);
        void DeleteEventUserResult(EventUserResult eventUserResult);
        void UpdateEventUserResult(EventUserResult eventUserResult);
        Task<bool> SaveAllAsync();
    }
}