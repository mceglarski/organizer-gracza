using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface ITeamsRepository
    {
        Task<Team> GetTeamAsync(int teamId);
        Task<Team> GetTeamByNameAsync(string name);
        Task<IEnumerable<Team>> GetTeamsAsync();
        void AddTeam(Team team);
        void DeleteTeam(Team team);
        Task<bool> SaveAllAsync();
        void UpdateTeam(Team team);
    }
}