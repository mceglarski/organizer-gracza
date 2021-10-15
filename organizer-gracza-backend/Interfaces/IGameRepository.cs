using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IGameRepository
    {
        Task<Game> GetGameAsync(int gameId);
        Task<IEnumerable<Game>> GetGamesAsync();
        void AddGame(Game game);
        void DeleteGame(Game game);
        Task<bool> SaveAllAsync();
    }
}