using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    public class UserGameController : BaseApiController
    {
        private readonly IUserGamesRepository _userGamesRepository;
        private readonly IMapper _mapper;

        public UserGameController(IUserGamesRepository userGamesRepository, IMapper mapper)
        {
            _userGamesRepository = userGamesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGameDto>>> GetUserGamesAsync()
        {
            var userGames = await _userGamesRepository.GetUsersGamesAsync();

            var userGamesToReturn = _mapper.Map<IEnumerable<UserGameDto>>(userGames);

            return Ok(userGamesToReturn);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<UserGameDto>>> GetUserGamesForUserAsync(int userId)
        {
            var userGames = await _userGamesRepository.GetUsersForUsersGamesAsync(userId);

            var userGamesToReturn = _mapper.Map<IEnumerable<UserGameDto>>(userGames);

            return Ok(userGamesToReturn);
        }

        [HttpGet("game/{gameId}")]
        public async Task<ActionResult<IEnumerable<UserGameDto>>> GetUserGamesForGamesAsync(int gameId)
        {
            var userGames = await _userGamesRepository.GetGamesForUsersGamesAsync(gameId);

            var userGamesToReturn = _mapper.Map<IEnumerable<UserGameDto>>(userGames);

            return Ok(userGamesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserGameDto>> GetUserGame(int id)
        {
            var userGames = await _userGamesRepository.GetUserGameAsync(id);

            return _mapper.Map<UserGameDto>(userGames);
        }

        [HttpPost]
        public async Task<ActionResult<UserGameDto>> CreateUserGame(UserGameDto userGameDto)
        {
            var newUserGame = new UserGame()
            {
                UserId = userGameDto.UserId,
                GameId = userGameDto.GameId
            };

            _userGamesRepository.AddUserGame(newUserGame);

            if (await _userGamesRepository.SaveAllAsync())
                return Ok(_mapper.Map<UserGameDto>(newUserGame));
            return BadRequest("Failed to add user game");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserGame(int id)
        {
            var userGames = await _userGamesRepository.GetUserGameAsync(id);

            _userGamesRepository.DeleteUserGame(userGames);

            if (await _userGamesRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting user game");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserGame(UserGame userGame, int id)
        {
            var userGameAsync = await _userGamesRepository.GetUserGameAsync(id);

            userGameAsync.UserGameId = userGameAsync.UserGameId;
            userGameAsync.UserId = userGame.UserId;
            userGameAsync.GameId = userGame.GameId;

            if (await _userGamesRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update user game");
        }
    }
}