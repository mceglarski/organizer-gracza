using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using organizer_gracza_backend.Data;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    [Authorize]
    public class EventsUserRegistrationsController : BaseApiController
        {
        private readonly DataContext _context;
        private readonly IEventUserRegistrationRepository _eventUserRegistrationRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoEventService _photoEventService;

        public EventsUserRegistrationsController(DataContext context,IPhotoEventService photoEventService, 
            IEventUserRegistrationRepository eventUserRegistrationRepository, IMapper mapper)
        {
            _context = context;
            _eventUserRegistrationRepository = eventUserRegistrationRepository;
            _mapper = mapper;
            _photoEventService = photoEventService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventUserRegistrationDto>>> GetEventsUserRegistrationsAsync()
        {
            var events = await _eventUserRegistrationRepository
                .GetEventsUserRegistrationAsync();

            var eventsToReturn = _mapper.Map<IEnumerable<EventUserRegistrationDto>>(events);

            return Ok(eventsToReturn);
        }
        
        [HttpGet("event/{id}")]
        public async Task<ActionResult<IEnumerable<EventUserRegistrationDto>>> GetEventRegistrations(int id)
        {
            var events = await _eventUserRegistrationRepository
                .GetEventRegistrationAsync(id);

            var eventsToReturn = _mapper.Map<IEnumerable<EventUserRegistrationDto>>(events);

            return Ok(eventsToReturn);
        }

        [HttpGet("{id}", Name = "GetEventUserRegistration")]
        public async Task<ActionResult<EventUserRegistrationDto>> GetEventUserRegistrationAsync(int id)
        {
            var specifiedEvent = await _eventUserRegistrationRepository.GetEventUserRegistrationAsync(id);

            return _mapper.Map<EventUserRegistrationDto>(specifiedEvent);
        }

        [HttpPost]
        public async Task<ActionResult<EventUserRegistrationDto>> CreateEventUserRegistration
            (EventUserRegistrationDto eventUserRegistrationDto)
        {
            var newEventUserRegistration = new EventUserRegistration()
            {
                EventUserId = eventUserRegistrationDto.EventUserId,
                UserId = eventUserRegistrationDto.UserId
            };
            
            var userRegistrations = await _eventUserRegistrationRepository.GetEventsUserRegistrationAsync();

            if (userRegistrations.Any(teamUser => newEventUserRegistration.EventUserId == 
                teamUser.EventUserId && newEventUserRegistration.UserId == teamUser.UserId))
            {
                return BadRequest("Nie można dołączyć do wydarzenia, której jest się już członkiem");
            }
            

            _eventUserRegistrationRepository.AddEventUserRegistration(newEventUserRegistration);

            if (await _eventUserRegistrationRepository.SaveAllAsync())
                return Ok(_mapper.Map<EventUserRegistrationDto>(newEventUserRegistration));
            return BadRequest("Failed to add registration for users event");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEventUserRegistration(int id)
        {
            var specifiedEvent = await _eventUserRegistrationRepository.GetEventUserRegistrationAsync(id);

            _eventUserRegistrationRepository.DeleteEventUserRegistration(specifiedEvent);

            if (await _eventUserRegistrationRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting event registration for users");
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
    }
}