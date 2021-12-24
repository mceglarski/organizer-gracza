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

        public EventUserResultController(DataContext context, IEventUserResultRepository eventUserResultRepository,
            IMapper mapper)
        {
            _context = context;
            _eventUserResultRepository = eventUserResultRepository;
            _mapper = mapper;
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

            if (await _eventUserResultRepository.SaveAllAsync())
                return Ok(_mapper.Map<EventUserResultDto>(newEventUserResult));
            return BadRequest("Failed to add event user result");
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