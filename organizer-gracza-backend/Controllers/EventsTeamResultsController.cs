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

        public EventsTeamResultsController(DataContext context, IEventTeamResultRepository eventTeamResultRepository,
            IMapper mapper)
        {
            _context = context;
            _eventTeamResultRepository = eventTeamResultRepository;
            _mapper = mapper;
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

            if (await _eventTeamResultRepository.SaveAllAsync())
                return Ok(_mapper.Map<EventTeamResultDto>(newEventTeamResult));
            return BadRequest("Failed to add event team result");
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