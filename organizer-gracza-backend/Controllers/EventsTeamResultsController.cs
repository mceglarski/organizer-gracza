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
    public class EventsTeamResultsController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IEventTeamResultRepository _eventTeamResultRepository;
        private readonly ITeamsRepository _teamsRepository;
        private readonly IEventTeamRepository _eventTeamRepository;
        private readonly ITeamUsersRepository _teamUsersRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGameStatisticsRepository _gameStatisticsRepository;
        private readonly IGeneralStatisticsRepository _generalStatisticsRepository;

        public EventsTeamResultsController(DataContext context, IEventTeamResultRepository eventTeamResultRepository,
            IMapper mapper, ITeamsRepository teamsRepository, IEventTeamRepository eventTeamRepository,
            ITeamUsersRepository teamUsersRepository, IUserRepository userRepository,
            IGameStatisticsRepository gameStatisticsRepository
            , IGeneralStatisticsRepository generalStatisticsRepository)
        {
            _context = context;
            _eventTeamResultRepository = eventTeamResultRepository;
            _mapper = mapper;
            _teamsRepository = teamsRepository;
            _eventTeamRepository = eventTeamRepository;
            _teamUsersRepository = teamUsersRepository;
            _userRepository = userRepository;
            _gameStatisticsRepository = gameStatisticsRepository;
            _generalStatisticsRepository = generalStatisticsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventTeamResultDto>>> GetEventsTeamResultsAsync()
        {
            var eventsTeamResults = await _eventTeamResultRepository.GetEventTeamResults();

            var eventsTeamResultsToReturn = _mapper.Map<IEnumerable<EventTeamResultDto>>(eventsTeamResults);

            return Ok(eventsTeamResultsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventTeamResultDto>> GetEventTeamResultByIdAsync(int id)
        {
            var eventTeamResult = await _eventTeamResultRepository.GetEventTeamResultById(id);

            return _mapper.Map<EventTeamResultDto>(eventTeamResult);
        }

        [HttpPost]
        public async Task<ActionResult<EventTeamResultDto>> CreateEventTeamResult(EventTeamResultDto eventTeamResultDto)
        {
            var newEventTeamResult = new EventTeamResult()
            {
                EventTeamResultId = eventTeamResultDto.EventTeamResultId,
                EventTeamId = eventTeamResultDto.EventTeamId,
                TeamId = eventTeamResultDto.TeamId
            };

            _eventTeamResultRepository.AddEventTeamResult(newEventTeamResult);

            if (!await _eventTeamResultRepository.SaveAllAsync())
                return BadRequest("Failed to add event team result");

            var teamWinnerId = eventTeamResultDto.TeamId;
            var teamWinner = _teamsRepository.GetTeamAsync(teamWinnerId);

            var eventTeamId = eventTeamResultDto.EventTeamId;
            var eventTeam = _eventTeamRepository.GetEventTeamAsync(eventTeamId);

            eventTeam.Result.EventTeamResultId = newEventTeamResult.EventTeamResultId;
            if (!await _eventTeamRepository.SaveAllAsync())
                return BadRequest("Failed to save result");

            List<int> listOfUserIds = new List<int>();

            foreach (var teamId in eventTeam.Result.EventTeamRegistration)
            {
                var teamUsers = _teamUsersRepository.GetUsersInTeamCollection(teamId.TeamId);

                foreach (var userInTeam in teamUsers.Result)
                {
                    var specifiedUser = await _userRepository.GetUserByIdAsync(userInTeam.UserId);
                    if (listOfUserIds.Contains(specifiedUser.Id))
                        break;
                    listOfUserIds.Add(specifiedUser.Id);
                    var gameStatistics =
                        _gameStatisticsRepository.GetGameStatisticsForUser(specifiedUser.Id, eventTeam.Result.GameId);
                    if (gameStatistics.Result == null)
                    {
                        var newGameStatistics = new GameStatistics()
                        {
                            GameId = eventTeam.Result.GameId,
                            LostGames = 1,
                            WonGames = 0,
                            UserId = specifiedUser.Id
                        };

                        _context.GameStatistics.Add(newGameStatistics);
                    }

                    else
                    {
                        gameStatistics.Result.LostGames++;
                    }
                    
                    if (!await _gameStatisticsRepository.SaveAllAsync())
                        return BadRequest("Failed to save game statistics");
                    
                    var generalStatistics =
                        _generalStatisticsRepository.GetGeneralStatisticsByUserIdAsync(specifiedUser.Id);
                    generalStatistics.Result.EventsParticipated++;
                }
            }

            var teamUsersWinner = _teamUsersRepository.GetUsersInTeamCollection(teamWinnerId);

            foreach (var userInWinnerTeam in teamUsersWinner.Result)
            {
                var usersWinner = _userRepository.GetUserByIdAsync(userInWinnerTeam.UserId);
                var gameStatisticsWinner =
                    _gameStatisticsRepository.GetGameStatisticsForUser(usersWinner.Result.Id, eventTeam.Result.GameId);
                if (gameStatisticsWinner.Result == null)
                {
                    var newGameStatistics = new GameStatistics()
                    {
                        GameId = eventTeam.Result.GameId,
                        LostGames = 0,
                        WonGames = 1,
                        UserId = usersWinner.Result.Id
                    };

                    _context.GameStatistics.Add(newGameStatistics);
                }
                else
                {
                    gameStatisticsWinner.Result.LostGames--;
                    gameStatisticsWinner.Result.WonGames++;
                }
                var generalStatistics =
                    _generalStatisticsRepository.GetGeneralStatisticsByUserIdAsync(usersWinner.Result.Id);
                generalStatistics.Result.EventsWon++;
            }

            if (!await _gameStatisticsRepository.SaveAllAsync())
                return BadRequest("Failed to save game statistics");

            return Ok(_mapper.Map<EventTeamResultDto>(newEventTeamResult));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEventTeamResult(int id)
        {
            var eventTeamResult = await _eventTeamResultRepository.GetEventTeamResultById(id);

            _eventTeamResultRepository.DeleteEventTeamResult(eventTeamResult);

            if (await _eventTeamResultRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting event team result");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEventTeamResult(EventTeamResult eventTeamResult, int id)
        {
            var eventTeamResultAsync = await _eventTeamResultRepository.GetEventTeamResultById(id);

            eventTeamResultAsync.EventTeamResultId = eventTeamResultAsync.EventTeamResultId;
            eventTeamResultAsync.EventTeamId = eventTeamResult.EventTeamId;
            eventTeamResultAsync.TeamId = eventTeamResult.TeamId;

            if (await _eventTeamResultRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update event team result");
        }
    }
}