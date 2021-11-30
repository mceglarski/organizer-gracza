using System;
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


        public TeamsController(DataContext context, ITeamsRepository teamsRepository, IMapper mapper,
            IPhotoService photoService, IUserAchievementCounterRepository userAchievementCounterRepository)
        {
            _context = context;
            _teamsRepository = teamsRepository;
            _mapper = mapper;
            _photoService = photoService;
            _userAchievementCounterRepository = userAchievementCounterRepository;
        }

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
                return BadRequest("Name is taken");
            
            var newTeam = new Team()
            {
                Name = teamDto.Name,
                PhotoUrl = teamDto.PhotoUrl
            };

            _teamsRepository.AddTeam(newTeam);

            if (!await _teamsRepository.SaveAllAsync()) 
                return BadRequest("Failed to add team");
            
            var userAchievement =
                _userAchievementCounterRepository.GetUserAchievementCounterByUsernameAsync(User.GetUsername());

            // userAchievement.Result.NumberOfTeamsCreated++;
                
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
            return await _context.Teams.AnyAsync(x => x.Name.ToLower() == name.ToLower());
        }
    }
}