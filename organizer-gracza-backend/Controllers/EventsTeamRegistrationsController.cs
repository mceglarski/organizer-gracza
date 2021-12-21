using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    [Authorize]
    public class EventsTeamRegistrationsController : BaseApiController
    {
        private readonly IEventTeamRegistrationRepository _eventTeamRegistrationRepository;
        private readonly IMapper _mapper;

        public EventsTeamRegistrationsController(
            IEventTeamRegistrationRepository eventTeamRegistrationRepository, IMapper mapper)

        {
            _eventTeamRegistrationRepository = eventTeamRegistrationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventTeamRegistrationDto>>> GetEventsTeamRegistrationsAsync()
        {
            var events = await _eventTeamRegistrationRepository
                .GetEventsTeamRegistrationAsync();

            var eventsToReturn = _mapper.Map<IEnumerable<EventTeamRegistrationDto>>(events);

            return Ok(eventsToReturn);
        }

        [HttpGet("{id}", Name = "GetEventTeamRegistration")]
        public async Task<ActionResult<EventTeamRegistrationDto>> GetEventTeamRegistrationAsync(int id)
        {
            var specifiedEvent = await _eventTeamRegistrationRepository.GetEventTeamRegistrationAsync(id);

            return _mapper.Map<EventTeamRegistrationDto>(specifiedEvent);
        }

        [HttpGet("event/{id}")]
        public async Task<ActionResult<IEnumerable<EventTeamRegistrationDto>>> GetEventRegistration(int id)
        {
            var specifiedEvent = await
                _eventTeamRegistrationRepository.GetEventRegistrationAsync(id);

            var eventsToReturn = _mapper.Map<IEnumerable<EventTeamRegistrationDto>>(specifiedEvent);

            return Ok(eventsToReturn);
        }

        [HttpPost]
        public async Task<ActionResult<EventTeamRegistrationDto>> CreateEventTeamRegistration
            (EventTeamRegistrationDto eventTeamRegistrationDto)
        {
            var newEventTeamRegistration = new EventTeamRegistration()
            {
                EventTeamId = eventTeamRegistrationDto.EventTeamId,
                TeamId = eventTeamRegistrationDto.TeamId,
                EventResultId = eventTeamRegistrationDto.EventResultId
            };

            var teamRegistration = await _eventTeamRegistrationRepository.GetEventsTeamRegistrationAsync();

            if (teamRegistration.Any(teamUser => newEventTeamRegistration.TeamId ==
                    teamUser.TeamId && newEventTeamRegistration.EventTeamId == teamUser.EventTeamId))
            {
                return BadRequest("Nie można zapisać swojej drużyny do wydarzenia, którego jest już członkiem");
            }

            _eventTeamRegistrationRepository.AddEventTeamRegistration(newEventTeamRegistration);

            if (await _eventTeamRegistrationRepository.SaveAllAsync())
                return Ok(_mapper.Map<EventTeamRegistrationDto>(newEventTeamRegistration));
            return BadRequest("Failed to add registration for teams event");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEventTeamRegistration(int id)
        {
            var specifiedEvent = await _eventTeamRegistrationRepository.GetEventTeamRegistrationAsync(id);

            _eventTeamRegistrationRepository.DeleteEventTeamRegistration(specifiedEvent);

            if (await _eventTeamRegistrationRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting event registration for teams");
        }
    }
}
// [HttpPost("add-photo/{id}")]
// public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file, int id)
// {
//     var specifiedEvent = await _eventTeamRegistrationRepository.GetEventTeamAsync(id);
//
//     var result = await _photoEventService.AddPhotoAsync(file);
//
//     if (result.Error != null)
//         return BadRequest(result.Error.Message);
//
//     var photo = new Photo()
//     {
//         Url = result.SecureUrl.AbsoluteUri,
//         PublicId = result.PublicId
//     };
//
//     specifiedEvent.PhotoUrl = photo.Url;
//
//     if (await _eventTeamRepository.SaveAllAsync())
//     {
//         return CreatedAtRoute("GetEventTeam", new {id = specifiedEvent.EventId}, _mapper.Map<PhotoDto>(photo));
//         // return _mapper.Map<PhotoDto>(photo);
//     }
//
//     return BadRequest("Problem occured when adding photo");
// }