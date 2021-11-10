using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    public class GameStatisticsController : BaseApiController
    {
        private readonly IGameStatisticsRepository _gameStatisticsRepository;
        private readonly IMapper _mapper;

        public GameStatisticsController(IGameStatisticsRepository gameStatisticsRepository,
            IMapper mapper)
        {
            _gameStatisticsRepository = gameStatisticsRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameStatisticsDto>>> GetGameStatisticsAsync()
        {
            var gameStatistics = await _gameStatisticsRepository.GetGameStatisticsAsync();

            var gameStatisticsToReturn = _mapper.Map<IEnumerable<GameStatisticsDto>>(gameStatistics);

            return Ok(gameStatisticsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameStatisticsDto>> GetGameStatisticsByIdAsync(int id)
        {
            var gameStatistics = await _gameStatisticsRepository.GetGameStatisticsByIdAsync(id);

            return _mapper.Map<GameStatisticsDto>(gameStatistics);
            
        }
        
        [HttpPost]
        public async Task<ActionResult<GameStatisticsDto>> CreateGameStatistics(GameStatisticsDto gameStatisticsDto)
        {
            var newGameStatistics = new GameStatistics()
            {
                WonGames = gameStatisticsDto.WonGames,
                LostGames = gameStatisticsDto.LostGames,
                GameId = gameStatisticsDto.GameId,
                UserId = gameStatisticsDto.UserId
            };

            _gameStatisticsRepository.AddGameStatistics(newGameStatistics);

            if (await _gameStatisticsRepository.SaveAllAsync())
                return Ok(_mapper.Map<GameStatisticsDto>(newGameStatistics));
            return BadRequest("Failed to add game statistics");
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGameStatistics(int id)
        {
            var gameStatistic = await _gameStatisticsRepository.GetGameStatisticsByIdAsync(id);

            _gameStatisticsRepository.DeleteGameStatistics(gameStatistic);

            if (await _gameStatisticsRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting game statistics");
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGameStatistics(GameStatistics gameStatistics, int id)
        {
            var gameStatisticsAsync = await _gameStatisticsRepository.GetGameStatisticsByIdAsync(id);

            gameStatisticsAsync.GameStatisticsId = gameStatisticsAsync.GameStatisticsId;
            if (gameStatistics.WonGames != null)
                gameStatisticsAsync.WonGames = gameStatistics.WonGames;
            if (gameStatistics.LostGames != null)
                gameStatisticsAsync.LostGames = gameStatistics.LostGames;

            if (await _gameStatisticsRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update game statistics");
        }
    }
}