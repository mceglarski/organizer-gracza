using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IUserGamesRepository
    {
        Task<UserGame> GetUserGameAsync(int userGameId);
        Task<IEnumerable<UserGame>> GetUsersGamesAsync();
        Task<IEnumerable<UserGame>> GetUsersForUsersGamesAsync(int userId);
        Task<IEnumerable<UserGame>> GetGamesForUsersGamesAsync(int gameId);
        void AddUserGame(UserGame userGame);
        void DeleteUserGame(UserGame userGame);
        Task<bool> SaveAllAsync();
        void UpdateUserGame(UserGame userGame);
    }
}