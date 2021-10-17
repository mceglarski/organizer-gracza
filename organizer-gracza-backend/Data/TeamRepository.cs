using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class TeamRepository : ITeamsRepository
    {
        private readonly DataContext _context;
        private readonly ITeamUsersRepository _teamUsersRepository;

        public TeamRepository(DataContext context, ITeamUsersRepository teamUserRepository)
        {
            _teamUsersRepository = teamUserRepository;
            _context = context;
        }

        public async Task<Team> GetTeamAsync(int teamId)
        {
            return await _context.Teams
                .Include(t => t.TeamUser)
                .FirstOrDefaultAsync(x => x.TeamId == teamId);
        }

        public async Task<Team> GetTeamByNameAsync(string name)
        {
            return await _context.Teams
                .Include(t => t.TeamUser)
                .FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Team>> GetTeamsAsync()
        {
            return await _context.Teams
                .Include(t => t.TeamUser)
                .ToListAsync();
        }
        
        
        public void AddTeam(Team team)
        {
            _context.Teams.Add(team);
        }

        public void DeleteTeam(Team team)
        {
            _context.Teams.Remove(team);
        }

        public void UpdateTeam(Team team)
        {
            _context.Attach(team);
            _context.Entry(team).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}