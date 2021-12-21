using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    [Authorize]
    public class TeamUsersController : BaseApiController
    {
        private readonly ITeamUsersRepository _teamUsersRepository;
        private readonly IMapper _mapper;
        private readonly IUserAchievementCounterRepository _userAchievementCounterRepository;

        public TeamUsersController(ITeamUsersRepository teamUsersRepository, IMapper mapper,
            IUserAchievementCounterRepository userAchievementCounterRepository)
        {
            _teamUsersRepository = teamUsersRepository;
            _mapper = mapper;
            _userAchievementCounterRepository = userAchievementCounterRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamUsersDto>>> GetTeamsUsersAsync()
        {
            var teamsUsers = await _teamUsersRepository.GetTeamsUsersAsync();

            var teamsUsersToReturn = _mapper.Map<IEnumerable<TeamUsersDto>>(teamsUsers);

            return Ok(teamsUsersToReturn);
        }

        [HttpGet("teams/{username}")]
        public async Task<ActionResult<IEnumerable<TeamUsersDto>>> GetTeamsForUsers(string username)
        {
            var userTeams = await _teamUsersRepository.GetTeamForUsersAsync(username);

            var teamsUsersToReturn = _mapper.Map<IEnumerable<TeamUsersDto>>(userTeams);

            return Ok(teamsUsersToReturn);
        }

        [HttpGet("teams/users/{teamId}")]
        public async Task<ActionResult<IEnumerable<UsersTeamsDto>>> GetUsersInTeams(int teamId)
        {
            var userTeams = await _teamUsersRepository.GetUsersInTeam(teamId);

            var teamsUsersToReturn = _mapper.Map<IEnumerable<UsersTeamsDto>>(userTeams);

            return Ok(teamsUsersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamUsersDto>> GetTeamUsersAsync(int id)
        {
            var teamUsers = await _teamUsersRepository.GetTeamUsersAsync(id);

            return _mapper.Map<TeamUsersDto>(teamUsers);
        }

        [HttpPost]
        public async Task<ActionResult<TeamDto>> CreateTeamUsers(TeamUsersDto teamUsersDto)
        {
            var newTeamUsers = new TeamUser()
            {
                UserId = teamUsersDto.UserId,
                TeamId = teamUsersDto.TeamId
            };

            var userTeams = await _teamUsersRepository.GetTeamsUsersAsync();

            if (userTeams.Any(teamUser =>
                teamUsersDto.TeamId == teamUser.TeamId && teamUsersDto.UserId == teamUser.UserId))
            {
                return BadRequest("Nie można dołączyć do drużyny, której jest się już członkiem");
            }

            _teamUsersRepository.AddTeamUser(newTeamUsers);

            if (!await _teamUsersRepository.SaveAllAsync()) 
                return BadRequest("Failed to add user for team");
            var userAchievement = await _userAchievementCounterRepository
                .GetUserAchievementCounterByIdAsync(teamUsersDto.UserId);
            userAchievement.NumberOfTeamsJoined++;

            return Ok(_mapper.Map<TeamUsersDto>(newTeamUsers));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeamUsers(int id)
        {
            var teamUsers = await _teamUsersRepository.GetTeamUsersAsync(id);

            _teamUsersRepository.DeleteTeamUser(teamUsers);

            if (await _teamUsersRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting user in team");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTeamUsers(TeamUser teamUser, int id)
        {
            var teamUsersAsync = await _teamUsersRepository.GetTeamUsersAsync(id);

            teamUsersAsync.TeamUserId = teamUsersAsync.TeamUserId;
            teamUsersAsync.UserId = teamUser.UserId;
            teamUsersAsync.TeamId = teamUser.TeamId;

            if (await _teamUsersRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update user in team");
        }
    }
}