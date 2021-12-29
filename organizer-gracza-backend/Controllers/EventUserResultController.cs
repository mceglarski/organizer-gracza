using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using organizer_gracza_backend.Data;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    public class EventUserResultController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IEventUserResultRepository _eventUserResultRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGameStatisticsRepository _gameStatisticsRepository;
        private readonly IEventUserRepository _eventUserRepository;
        private readonly IGeneralStatisticsRepository _generalStatisticsRepository;

        public EventUserResultController(DataContext context, IEventUserResultRepository eventUserResultRepository,
            IMapper mapper, IUserRepository userRepository, IGameStatisticsRepository gameStatisticsRepository,
            IEventUserRepository eventUserRepository, IGeneralStatisticsRepository generalStatisticsRepository)
        {
            _context = context;
            _eventUserResultRepository = eventUserResultRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _gameStatisticsRepository = gameStatisticsRepository;
            _eventUserRepository = eventUserRepository;
            _generalStatisticsRepository = generalStatisticsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventUserResultDto>>> GetEventsUserResultsAsync()
        {
            var eventsUserResults = await _eventUserResultRepository.GetEventUserResults();

            var eventsUserResultsToReturn = _mapper.Map<IEnumerable<EventUserResultDto>>(eventsUserResults);

            return Ok(eventsUserResultsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventUserResultDto>> GetEventUserResultByIdAsync(int id)
        {
            var eventUserResult = await _eventUserResultRepository.GetEventUserResultById(id);

            return _mapper.Map<EventUserResultDto>(eventUserResult);
        }

        [HttpPost]
        public async Task<ActionResult<EventUserResultDto>> CreateEventUserResult(EventUserResultDto eventUserResultDto)
        {
            var newEventUserResult = new EventUserResult()
            {
                EventUserResultId = eventUserResultDto.EventUserResultId,
                EventUserId = eventUserResultDto.EventUserId,
                UserId = eventUserResultDto.UserId
            };

            _eventUserResultRepository.AddEventUserResult(newEventUserResult);

            if (!await _eventUserResultRepository.SaveAllAsync())
                return BadRequest("Failed to add event user result");

            int userId = eventUserResultDto.UserId;
            var user = await _userRepository.GetUserByIdAsync(userId);

            var eventUserId = eventUserResultDto.EventUserId;
            var eventUser = await _eventUserRepository.GetEventUserAsync(eventUserId);

            eventUser.EventUserResultId = newEventUserResult.EventUserResultId;
            if (!await _eventUserRepository.SaveAllAsync())
                return BadRequest("Failed to add event user result");

            int gameId = eventUser.GameId;
            var game = await _gameStatisticsRepository.GetGameStatisticsByIdAsync(gameId);

            foreach (var userIds in eventUser.EventUserRegistration)
            {
                var userParticipiant = _userRepository.GetUserByIdAsync(userIds.UserId);
                var gameStats = _gameStatisticsRepository.GetGameStatisticsForUser(userParticipiant.Result.Id, gameId);
                gameStats.Result.LostGames++;

                if (!await _gameStatisticsRepository.SaveAllAsync())
                    return BadRequest("Failed to save game statistics");
            }

            var gameStatsForWinner = _gameStatisticsRepository.GetGameStatisticsForUser(userId, gameId);
            gameStatsForWinner.Result.LostGames--;
            gameStatsForWinner.Result.WonGames++;
            var generalStatistics = _generalStatisticsRepository.GetGeneralStatisticsByUserIdAsync(userId);
            generalStatistics.Result.EventsWon++;
            generalStatistics.Result.EventsParticipated++;
            
            if (!await _gameStatisticsRepository.SaveAllAsync())
                return BadRequest("Failed to save game statistics for the winner");

            return Ok(_mapper.Map<EventUserResultDto>(newEventUserResult));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEventUserResult(int id)
        {
            var eventUserResult = await _eventUserResultRepository.GetEventUserResultById(id);

            _eventUserResultRepository.DeleteEventUserResult(eventUserResult);

            if (await _eventUserResultRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting event user result");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEventTeamResult(EventUserResult eventUserResult, int id)
        {
            var eventUserResultAsync = await _eventUserResultRepository.GetEventUserResultById(id);

            eventUserResultAsync.EventUserResultId = eventUserResultAsync.EventUserResultId;
            eventUserResultAsync.UserId = eventUserResult.UserId;
            eventUserResultAsync.EventUserId = eventUserResult.EventUserId;

            if (await _eventUserResultRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update event user result");
        }
    }
}