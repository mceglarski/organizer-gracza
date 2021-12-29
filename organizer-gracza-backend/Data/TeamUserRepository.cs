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

        public async Task<IEnumerable<TeamUser>> GetTeamForUsersByIdAsync(int userId)
        {
            return await _context.TeamUsers
                .Include(u => u.User)
                .Include(t => t.Team)
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<TeamUser>> GetUsersInTeam(int teamId)
        {
            return await _context.TeamUsers
                .Include(t => t.Team)
                .Include(u => u.User)
                .Where(x => x.TeamId == teamId)
                .ToListAsync();
        }

        public async Task<ICollection<TeamUser>> GetUsersInTeamCollection(int teamId)
        {
            return await _context.TeamUsers
                .Include(t => t.Team)
                .Include(u => u.User)
                .Where(t => t.TeamId == teamId)
                .ToListAsync();
        }

        public int GetNumberOfTeamsForUser(int userId)
        {
            return _context.TeamUsers
                .Include(e => e.User)
                .Include(t => t.Team)
                .Count(x => x.UserId == userId);
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