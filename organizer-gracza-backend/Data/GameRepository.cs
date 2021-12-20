using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class GameRepository : IGameRepository
    {
        private readonly DataContext _context;

        public GameRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Game> GetGameAsync(int gameId)
        {
            return await _context.Games
                .SingleOrDefaultAsync(x => x.GameId == gameId);
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await _context.Games
                .ToListAsync();
        }

        public void AddGame(Game game)
        {
            _context.Games.Add(game);
        }

        public void DeleteGame(Game game)
        {
            _context.Games.Remove(game);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}