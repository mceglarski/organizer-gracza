using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IEventTeamResultRepository
    {
        Task<EventTeamResult> GetEventTeamResultById(int eventTeamResultId);
        Task<IEnumerable<EventTeamResult>> GetEventTeamResults();
        void AddEventTeamResult(EventTeamResult eventTeamResult);
        void DeleteEventTeamResult(EventTeamResult eventTeamResult);
        void UpdateEventTeamResult(EventTeamResult eventTeamResult);
        Task<bool> SaveAllAsync();
    }
}