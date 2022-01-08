using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using organizer_gracza_backend.Data;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Extensions;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    [Authorize]
    public class TeamsController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITeamsRepository _teamsRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly IUserAchievementCounterRepository _userAchievementCounterRepository;
        private readonly IUserAchievementRepository _userAchievementRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITeamUsersRepository _teamUsersRepository;

        public TeamsController(DataContext context, ITeamsRepository teamsRepository, IMapper mapper,
            IPhotoService photoService, IUserAchievementCounterRepository userAchievementCounterRepository,
            IUserAchievementRepository userAchievementRepository, IUserRepository userRepository,
            ITeamUsersRepository teamUsersRepository)
        {
            _context = context;
            _teamsRepository = teamsRepository;
            _mapper = mapper;
            _photoService = photoService;
            _userAchievementCounterRepository = userAchievementCounterRepository;
            _userAchievementRepository = userAchievementRepository;
            _userRepository = userRepository;
            _teamUsersRepository = teamUsersRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeamsAsync()
        {
            var teams = await _teamsRepository.GetTeamsAsync();

            var teamsToReturn = _mapper.Map<IEnumerable<TeamDto>>(teams);

            return Ok(teamsToReturn);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDto>> GetTeamAsync(int id)
        {
            var team = await _teamsRepository.GetTeamAsync(id);

            return _mapper.Map<TeamDto>(team);
        }
        
        [HttpGet("details/{name}", Name = "GetTeam")]
        public async Task<ActionResult<TeamDto>> GetTeamByNameAsync(string name)
        {
            var team = await _teamsRepository.GetTeamByNameAsync(name);

            return _mapper.Map<TeamDto>(team);
        }

        [HttpPost]
        public async Task<ActionResult<TeamDto>> CreateTeam(TeamDto teamDto)
        {
            teamDto.Name = Strings.Trim(teamDto.Name);
            
            if (await NameExists(teamDto.Name))
                return BadRequest("Name is already taken");
            
            if (await NameExistsToLower(teamDto.Name.ToLower()))
                return BadRequest("Name is already taken");
            
            var newTeam = new Team()
            {
                Name = teamDto.Name,
                PhotoUrl = teamDto.PhotoUrl
            };

            newTeam.PhotoUrl ??= "https://i.ibb.co/Z2RJhWy/T.png";

            _teamsRepository.AddTeam(newTeam);

            if (!await _teamsRepository.SaveAllAsync()) 
                return BadRequest("Failed to add team");

            var userId = _userRepository.GetUserByUsernameAsync(User.GetUsername());

            var newTeamUser = new TeamUser()
            {
                UserId = userId.Result.Id,
                TeamId = newTeam.TeamId
            };
            
            _teamUsersRepository.AddTeamUser(newTeamUser);
            
            if (!await _teamUsersRepository.SaveAllAsync())
                return BadRequest("Failed to join created team");

            var userAchievement =
                _userAchievementCounterRepository.GetUserAchievementCounterByUsernameAsync(User.GetUsername());

            userAchievement.Result.NumberOfTeamsJoined++;
            userAchievement.Result.NumberOfTeamsCreated++;

            if (!await _userAchievementCounterRepository.SaveAllAsync())
                return BadRequest("Failed to add increase counter");

            if (userAchievement.Result.NumberOfTeamsCreated == 1)
            {

                var query = _userRepository.GetUserByUsernameAsync(User.GetUsername());
                
                var newUserAchievement = new UserAchievement()
                {
                    UserId = query.Result.Id,
                    AchievementsId = 1
                };

                _userAchievementRepository.AddUserAchievement(newUserAchievement);

                if (!await _userAchievementRepository.SaveAllAsync())
                    return BadRequest("Failed to add 'Samotnik' achievement");
            }
                
            return Ok(_mapper.Map<TeamDto>(newTeam));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeam(int id)
        {
            var team = await _teamsRepository.GetTeamAsync(id);

            _teamsRepository.DeleteTeam(team);

            if (await _teamsRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting team");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTeam(Team team, int id)
        {
            team.Name = Strings.Trim(team.Name);
            var teamAsync = await _teamsRepository.GetTeamAsync(id);

            teamAsync.TeamId = teamAsync.TeamId;
            if (team.Name != null)
                teamAsync.Name = team.Name;

            if (await _teamsRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update team");
        }
        
        [HttpPost("add-photo/{name}")]
        public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file, string name)
        {
            var team = await _teamsRepository.GetTeamByNameAsync(name);

            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null)
                return BadRequest(result.Error.Message);

            var photo = new Photo()
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            team.PhotoUrl = photo.Url;

            if (await _teamsRepository.SaveAllAsync())
            {
                return CreatedAtRoute("GetTeam", new {name = team.Name},
                    _mapper.Map<PhotoDto>(photo));
            }
            return BadRequest("Problem adding photo");
        }
        
        private async Task<bool> NameExists(string name)
        {
            return await _context.Teams.AnyAsync(x => x.Name.Equals(name));
        }
        
        private async Task<bool> NameExistsToLower(string name)
        {
            return await _context.Teams.AnyAsync(x => x.Name.ToLower().Equals(name.ToLower()));
        }
    }
}