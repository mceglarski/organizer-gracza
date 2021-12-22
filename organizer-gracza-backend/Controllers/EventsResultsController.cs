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
    public class EventsResultsController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IEventResultRepository _eventResultRepository;

        public EventsResultsController(DataContext context, IEventResultRepository eventResultRepository,
            IMapper mapper)
        {
            _context = context;
            _eventResultRepository = eventResultRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventResultDto>>> GetEventsResultsAsync()
        {
            var eventsResults = await _eventResultRepository.GetEventResults();

            var eventsResultsToReturn = _mapper.Map<IEnumerable<EventResultDto>>(eventsResults);

            return Ok(eventsResultsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventResultDto>> GetEventResultByIdAsync(int id)
        {
            var eventResult = await _eventResultRepository.GetEventResultById(id);

            return _mapper.Map<EventResultDto>(eventResult);
        }
        
        [HttpPost]
        public async Task<ActionResult<EventResultDto>> CreateEventResult(EventResultDto eventResultDto)
        {
            var newEventResult = new EventResult()
            {
                EventResultId = eventResultDto.EventResultId,
                WinnerName = eventResultDto.WinnerName,
                EventTeamRegistrationId = eventResultDto.EventTeamRegistrationId,
                EventUserRegistrationId = eventResultDto.EventUserRegistrationId
            };

            _eventResultRepository.AddEventResult(newEventResult);

            if (await _eventResultRepository.SaveAllAsync())
                return Ok(_mapper.Map<EventResultDto>(newEventResult));
            return BadRequest("Failed to add event result");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEventResult(int id)
        {
            var eventResult = await _eventResultRepository.GetEventResultById(id);

            _eventResultRepository.DeleteEventResult(eventResult);

            if (await _eventResultRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting event result");
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEventResult(EventResult eventResult, int id)
        {
            var eventResultAsync = await _eventResultRepository.GetEventResultById(id);

            eventResultAsync.EventResultId = eventResultAsync.EventResultId;
            if (eventResult.WinnerName != null)
                eventResultAsync.WinnerName = eventResult.WinnerName;

            if (await _eventResultRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update event result");
        }
    }
}