using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IEventResultRepository
    {
        Task<EventResult> GetEventResultById(int eventResultId);
        Task<IEnumerable<EventResult>> GetEventResults();
        void AddEventResult(EventResult eventResult);
        void DeleteEventResult(EventResult eventResult);
        void UpdateEventResult(EventResult eventResult);
        Task<bool> SaveAllAsync();
    }
}