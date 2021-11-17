using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    public class UserAchievementCounterController : BaseApiController
    {
        private readonly IUserAchievementCounterRepository _userAchievementCounterRepository;
        private readonly IMapper _mapper;

        public UserAchievementCounterController(IUserAchievementCounterRepository userAchievementCounterRepository
            , IMapper mapper)
        {
            _userAchievementCounterRepository = userAchievementCounterRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAchievementCounterDto>>> GetUserAchievementCounterAsync()
        {
            var userAchievementCounter = await _userAchievementCounterRepository
                .GetUserAchievementCounterAsync();

            var userAchievementCounterToReturn = _mapper.Map
                <IEnumerable<UserAchievementCounterDto>>(userAchievementCounter);

            return Ok(userAchievementCounterToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserAchievementCounterDto>> GetUserAchievementCounterByIdAsync(int id)
        {
            var userAchievementCounter = await _userAchievementCounterRepository.GetUserAchievementCounterByIdAsync(id);

            return _mapper.Map<UserAchievementCounterDto>(userAchievementCounter);
        }

        [HttpGet("userId/{id}")]
        public async Task<ActionResult<IEnumerable<UserAchievementCounterDto>>> GetUserAchievementCounterByUserIdAsync
            (int id)
        {
            var userAchievementCounter = await _userAchievementCounterRepository
                .GetUserAchievementCounterByUserId(id);

            var userAchievementCounterToReturn = _mapper.Map<IEnumerable<UserAchievementCounterDto>>(userAchievementCounter);

            return Ok(userAchievementCounterToReturn);
        }
        
        [HttpGet("userUsername/{username}")]
        public async Task<ActionResult<IEnumerable<UserAchievementCounterDto>>> GetUserAchievementCounterByUserIdAsync
            (string username)
        {
            var userAchievementCounter = await _userAchievementCounterRepository
                .GetUserAchievementCounterByUsernameAsync(username);

            var userAchievementCounterToReturn = _mapper.Map<IEnumerable<UserAchievementCounterDto>>(userAchievementCounter);

            return Ok(userAchievementCounterToReturn);
        }
        
        [HttpGet("specifiedachievement/{userId}/{userAchievementCounterId}")]
        public async Task<ActionResult<UserAchievementCounterDto>> GetUserAchievementCounterByIdsAsync
        (int userAchievementCounterId, int userId)
        {
            var userAchievementCounter = await _userAchievementCounterRepository.GetUserAchievementCounterByIds
                (userAchievementCounterId, userId);

            return _mapper.Map<UserAchievementCounterDto>(userAchievementCounter);
        }

        [HttpPost]
        public async Task<ActionResult<UserAchievementCounterDto>> CreateUserAchievementCounter
            (UserAchievementCounterDto userAchievementCounterDto)
        {
            var newUserAchievementCounter = new UserAchievementCounter()
            {
                NumberOfTeamsCreated = userAchievementCounterDto.NumberOfTeamsCreated,
                NumberOfTeamsJoined = userAchievementCounterDto.NumberOfTeamsJoined,
                UserId = userAchievementCounterDto.UserId
            };

            _userAchievementCounterRepository.AddUserAchievementCounter(newUserAchievementCounter);

            if (await _userAchievementCounterRepository.SaveAllAsync())
                return Ok(_mapper.Map<UserAchievementCounterDto>(newUserAchievementCounter));
            return BadRequest("Failed to add user achievement counter");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAchievementCounter(int id)
        {
            var userAchievementCounter = await _userAchievementCounterRepository.GetUserAchievementCounterByIdAsync(id);

            _userAchievementCounterRepository.DeleteUserAchievementCounter(userAchievementCounter);

            if (await _userAchievementCounterRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting user achievement counter");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserAchievementCounter(UserAchievementCounter userAchievementCounter
            , int id)
        {
            var userAchievementCounterAsync = await _userAchievementCounterRepository
                .GetUserAchievementCounterByIdAsync(id);

            userAchievementCounterAsync.UserAchievementCounterId = userAchievementCounterAsync.UserAchievementCounterId;
            if (userAchievementCounter.NumberOfTeamsCreated != null)
                userAchievementCounterAsync.NumberOfTeamsCreated = userAchievementCounter.NumberOfTeamsCreated;
            if (userAchievementCounter.NumberOfTeamsJoined != null)
                userAchievementCounterAsync.NumberOfTeamsJoined = userAchievementCounter.NumberOfTeamsJoined;

            if (await _userAchievementCounterRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update user achievement counter");
        }
    }
}