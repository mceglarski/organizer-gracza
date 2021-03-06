using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IGameStatisticsRepository
    {
        Task<GameStatistics> GetGameStatisticsByIdAsync(int gameStatisticsId);
        Task<GameStatistics> GetGameStatisticsForUser(int userId, int gameId);
        Task<IEnumerable<GameStatistics>> GetGameStatisticsByUserId(int userId);
        Task<IEnumerable<GameStatistics>> GetGameStatisticsAsync();
        void AddGameStatistics(GameStatistics gameStatistics);
        void DeleteGameStatistics(GameStatistics gameStatistics);
        Task<bool> SaveAllAsync();       
        void UpdateGameStatistics(GameStatistics gameStatistics);
    }
}