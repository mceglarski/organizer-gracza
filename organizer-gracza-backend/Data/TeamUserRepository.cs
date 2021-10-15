using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class TeamUserRepository : ITeamUsersRepository
    {
        private readonly DataContext _context;

        public TeamUserRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<TeamUser> GetTeamUsersAsync(int teamId)
        {
            return await _context.TeamUsers
                .Include(u => u.User)
                .Include(t => t.Team)
                .FirstOrDefaultAsync(x => x.TeamId == teamId);
        }
        public async Task<IEnumerable<TeamUser>> GetTeamsUsersAsync()
        {
            return await _context.TeamUsers
                .Include(u => u.User)
                .Include(t => t.Team)
                .ToListAsync();
        }

        public async Task<IEnumerable<TeamUser>> GetTeamForUsersAsync(string username)
        {
            return await _context.TeamUsers
                .Include(u => u.User)
                .Include(t => t.Team)
                .Where(x => x.User.UserName == username)
                .ToListAsync();
        }

        public void AddTeamUser(TeamUser teamUser)
        {
            _context.TeamUsers.Add(teamUser);
        }

        public void DeleteTeamUser(TeamUser teamUser)
        {
            _context.TeamUsers.Remove(teamUser);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateTeamUsers(TeamUser teamUser)
        {
            _context.Attach(teamUser);
            _context.Entry(teamUser).State = EntityState.Modified;
        }
    }
}