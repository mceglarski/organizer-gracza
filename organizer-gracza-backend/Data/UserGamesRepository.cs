using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class UserGamesRepository : IUserGamesRepository
    {
        private readonly DataContext _context;

        public UserGamesRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<UserGame> GetUserGameAsync(int userGameId)
        {
            return await _context.UserGame
                .Include(t => t.User)
                .Include(g => g.Game)
                .FirstOrDefaultAsync(x => x.UserGameId == userGameId);
        }

        public async Task<IEnumerable<UserGame>> GetUsersGamesAsync()
        {
            return await _context.UserGame
                .Include(t => t.User)
                .Include(g => g.Game)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserGame>> GetUsersForUsersGamesAsync(int userId)
        {
            return await _context.UserGame
                .Include(t => t.User)
                .Include(g => g.Game)
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserGame>> GetGamesForUsersGamesAsync(int gameId)
        {
            return await _context.UserGame
                .Include(t => t.User)
                .Include(g => g.Game)
                .Where(x => x.GameId == gameId)
                .ToListAsync();
        }

        public void AddUserGame(UserGame userGame)
        {
            _context.UserGame.Add(userGame);
        }

        public void DeleteUserGame(UserGame userGame)
        {
            _context.UserGame.Remove(userGame);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateUserGame(UserGame userGame)
        {
            _context.Attach(userGame);
            _context.Entry(userGame).State = EntityState.Modified;
        }
    }
}