using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    public class UserAchievementController : BaseApiController
    {
        private readonly IUserAchievementRepository _userAchievementRepository;
        private readonly IMapper _mapper;

        public UserAchievementController(IUserAchievementRepository userAchievementRepository,
            IMapper mapper)
        {
            _userAchievementRepository = userAchievementRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAchievementDto>>> GetUserAchievementsAsync()
        {
            var userAchievements = await _userAchievementRepository.GetUserAchievementsAsync();

            var userAchievementsToReturn = _mapper.Map<IEnumerable<UserAchievementDto>>(userAchievements);

            return Ok(userAchievementsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserAchievementDto>> GetUserAchievementByIdAsync(int id)
        {
            var userAchievements = await _userAchievementRepository.GetUserAchievementByIdAsync(id);

            return _mapper.Map<UserAchievementDto>(userAchievements);
        }
        
        [HttpGet("userId/{userId}")]
        public async Task<ActionResult<IEnumerable<UserAchievementDto>>> GetUserAchievementByUserIdAsync(int userId)
        {
            var userAchievements = await _userAchievementRepository.GetUserAchievementsForUserAsync(userId);

            var userAchievementsToReturn = _mapper.Map<IEnumerable<UserAchievementDto>>(userAchievements);

            return Ok(userAchievementsToReturn);
        }
        
        [HttpGet("achievementId/{achievementId}")]
        public async Task<ActionResult<IEnumerable<UserAchievementDto>>> GetUserAchievementByAchievementIdAsync(int achievementId)
        {
            var userAchievements = await _userAchievementRepository.GetUserAchievementsForAchievementAsync(achievementId);

            var userAchievementsToReturn = _mapper.Map<IEnumerable<UserAchievementDto>>(userAchievements);

            return Ok(userAchievementsToReturn);
        }
        
        [HttpGet("userId/{userId}/achievementId/{achievementId}")]
        public async Task<ActionResult<UserAchievementDto>> GetUserAchievementByUserIdAndAchievementIdAsync(int userId, int achievementId)
        {
            var userAchievements = await _userAchievementRepository.GetUserAchievementsForUserAndAchievementAsync(userId, achievementId);

            return _mapper.Map<UserAchievementDto>(userAchievements);
        }

        [HttpPost]
        public async Task<ActionResult<UserAchievementDto>> CreateUserAchievement(UserAchievementDto userAchievementsDto)
        {
            var newUserAchievement = new UserAchievement()
            {
                UserId = userAchievementsDto.UserId,
                AchievementsId = userAchievementsDto.AchievementsId,
            };

            _userAchievementRepository.AddUserAchievement(newUserAchievement);

            if (await _userAchievementRepository.SaveAllAsync())
                return Ok(_mapper.Map<UserAchievementDto>(newUserAchievement));
            return BadRequest("Failed to add user achievement");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAchievement(int id)
        {
            var userAchievement = await _userAchievementRepository.GetUserAchievementByIdAsync(id);

            _userAchievementRepository.DeleteUserAchievement(userAchievement);

            if (await _userAchievementRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting user achievement");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserAchievement(UserAchievement userAchievements, int id)
        {
            var userAchievementAsync = await _userAchievementRepository.GetUserAchievementByIdAsync(id);

            userAchievementAsync.UserAchievementId = userAchievementAsync.UserAchievementId;
            if (userAchievements.AchievementsId != null)
                userAchievementAsync.AchievementsId = userAchievements.AchievementsId;
            if (userAchievements.UserId != null)
                userAchievementAsync.UserId = userAchievements.UserId;

            if (await _userAchievementRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update user achievement");
        }
    }
}