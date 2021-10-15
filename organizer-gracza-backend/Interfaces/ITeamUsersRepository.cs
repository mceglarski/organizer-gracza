using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface ITeamUsersRepository
    {
        Task<TeamUser> GetTeamUsersAsync(int teamId);
        Task<IEnumerable<TeamUser>> GetTeamsUsersAsync();
        Task<IEnumerable<TeamUser>> GetTeamForUsersAsync(string userId);
        void AddTeamUser(TeamUser teamUser);
        void DeleteTeamUser(TeamUser teamUser);
        Task<bool> SaveAllAsync();
        void UpdateTeamUsers(TeamUser teamUser);
    }
}