using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using organizer_gracza_backend.Data;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    public class AchievementsController : BaseApiController
    {
        private readonly IAchievementsRepository _achievementsRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public AchievementsController(IAchievementsRepository achievementsRepository,
            IMapper mapper, DataContext context)
        {
            _achievementsRepository = achievementsRepository;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AchievementsDto>>> GetAchievementsAsync()
        {
            var achievements = await _achievementsRepository.GetAchievementsAsync();

            var achievementsToReturn = _mapper.Map<IEnumerable<AchievementsDto>>(achievements);

            return Ok(achievementsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AchievementsDto>> GetAchievementsByIdAsync(int id)
        {
            var achievements = await _achievementsRepository.GetAchievementByIdAsync(id);

            return _mapper.Map<AchievementsDto>(achievements);
        }

        [HttpPost]
        public async Task<ActionResult<AchievementsDto>> CreateAchievement(AchievementsDto achievementsDto)
        {
            achievementsDto.Name = Strings.Trim(achievementsDto.Name);

            var newAchievement = new Achievements()
            {
                Details = achievementsDto.Details,
                Name = achievementsDto.Name,
            };
            
            if (await NameExists(achievementsDto.Name))
                return BadRequest("Name is already taken");
            
            if (await NameExistsToLower(achievementsDto.Name.ToLower()))
                return BadRequest("Name is already taken");

            _achievementsRepository.AddAchievement(newAchievement);

            if (await _achievementsRepository.SaveAllAsync())
                return Ok(_mapper.Map<AchievementsDto>(newAchievement));
            return BadRequest("Failed to add achievement");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAchievement(int id)
        {
            var achievement = await _achievementsRepository.GetAchievementByIdAsync(id);

            _achievementsRepository.DeleteAchievement(achievement);

            if (await _achievementsRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting achievement");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAchievement(Achievements achievements, int id)
        {
            achievements.Name = Strings.Trim(achievements.Name);
            
            var achievementAsync = await _achievementsRepository.GetAchievementByIdAsync(id);

            achievementAsync.AchievementsId = achievementAsync.AchievementsId;
            if (achievements.Name != null)
                achievementAsync.Name = achievements.Name;
            if (achievements.Details != null)
                achievementAsync.Details = achievements.Details;

            if (await _achievementsRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update achievement");
        }
        
        
        private async Task<bool> NameExists(string name)
        {

            return await _context.Achievements.AnyAsync(x => x.Name.Equals(name));
        }
        
        private async Task<bool> NameExistsToLower(string name)
        {
            return await _context.Achievements.AnyAsync(x => x.Name.ToLower().Equals(name.ToLower()));
        }
    }
}