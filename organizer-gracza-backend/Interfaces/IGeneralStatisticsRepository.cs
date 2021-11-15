using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IGeneralStatisticsRepository
    {
        Task<GeneralStatistics> GetGeneralStatisticsByIdAsync(int gameStatisticsId);
        Task<GeneralStatistics> GetGeneralStatisticsByUserIdAsync(int userId);
        Task<IEnumerable<GeneralStatistics>> GetGeneralStatisticsAsync();
        void AddGeneralStatistics(GeneralStatistics gameStatistics);
        void DeleteGeneralStatistics(GeneralStatistics gameStatistics);
        Task<bool> SaveAllAsync();       
        void UpdateGeneralStatistics(GeneralStatistics gameStatistics);
    }
}