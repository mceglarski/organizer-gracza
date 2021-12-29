using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface ITeamUsersRepository
    {
        Task<TeamUser> GetTeamUsersAsync(int teamId);
        Task<IEnumerable<TeamUser>> GetTeamsUsersAsync();
        Task<IEnumerable<TeamUser>> GetTeamForUsersAsync(string username);
        Task<IEnumerable<TeamUser>> GetTeamForUsersByIdAsync(int userId);
        Task<IEnumerable<TeamUser>> GetUsersInTeam(int teamId);
        Task<ICollection<TeamUser>> GetUsersInTeamCollection(int teamId);
        int GetNumberOfTeamsForUser(int userId);
        void AddTeamUser(TeamUser teamUser);
        void DeleteTeamUser(TeamUser teamUser);
        Task<bool> SaveAllAsync();
        void UpdateTeamUsers(TeamUser teamUser);
    }
}