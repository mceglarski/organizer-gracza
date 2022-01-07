using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Extensions;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    [Authorize]
    public class EventsUserRegistrationsController : BaseApiController
    {
        private readonly IEventUserRegistrationRepository _eventUserRegistrationRepository;
        private readonly IMapper _mapper;
        private readonly IUserAchievementCounterRepository _userAchievementCounterRepository;
        private readonly IUserAchievementRepository _userAchievementRepository;

        public EventsUserRegistrationsController(
            IEventUserRegistrationRepository eventUserRegistrationRepository, IMapper mapper,
            IUserAchievementCounterRepository userAchievementCounterRepository,
            IUserAchievementRepository userAchievementRepository)
        {
            _eventUserRegistrationRepository = eventUserRegistrationRepository;
            _mapper = mapper;
            _userAchievementCounterRepository = userAchievementCounterRepository;
            _userAchievementRepository = userAchievementRepository;
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
                UserId = eventUserRegistrationDto.UserId,
            };

            var userRegistrations = await _eventUserRegistrationRepository.GetEventsUserRegistrationAsync();

            if (userRegistrations.Any(teamUser => newEventUserRegistration.EventUserId ==
                    teamUser.EventUserId && newEventUserRegistration.UserId == teamUser.UserId))
            {
                return BadRequest("Nie można dołączyć do wydarzenia, której jest się już członkiem");
            }


            _eventUserRegistrationRepository.AddEventUserRegistration(newEventUserRegistration);

            if (!await _eventUserRegistrationRepository.SaveAllAsync())
                return BadRequest("Failed to add registration for users event");

            var userAchievement = await _userAchievementCounterRepository
                .GetUserAchievementCounterByUserId(newEventUserRegistration.UserId);

            userAchievement.NumberOfEventUserJoined++;

            if (!await _userAchievementCounterRepository.SaveAllAsync())
                return BadRequest("Failed to add increase counter");

            if (userAchievement.NumberOfEventUserJoined == 1)
            {
                var newUserAchievement = new UserAchievement()
                {
                    UserId = eventUserRegistrationDto.UserId,
                    AchievementsId = 3
                };

                _userAchievementRepository.AddUserAchievement(newUserAchievement);

                if (!await _userAchievementRepository.SaveAllAsync())
                    return BadRequest("Failed to add 'Samotnik' achievement");
            }

            if (userAchievement.NumberOfEventUserJoined == 10)
            {
                var newUserAchievement = new UserAchievement()
                {
                    UserId = eventUserRegistrationDto.UserId,
                    AchievementsId = 4
                };

                _userAchievementRepository.AddUserAchievement(newUserAchievement);

                if (!await _userAchievementRepository.SaveAllAsync())
                    return BadRequest("Failed to add 'Samotny Wilk' achievement");
            }

            return Ok(_mapper.Map<EventUserRegistrationDto>(newEventUserRegistration));
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
        
        [HttpDelete("delete/{eventUserId}/{userId}")]
        public async Task<ActionResult> DeleteEventUserRegistration(int eventUserId, int userId)
        {
            var specifiedEvent = await _eventUserRegistrationRepository.GetEventUserRegistrationForUserAsync(eventUserId, userId);

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