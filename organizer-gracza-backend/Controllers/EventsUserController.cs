using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using organizer_gracza_backend.Data;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    [Authorize]
    public class EventsUserController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IEventUserRepository _eventUserRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoEventService _photoEventService;

        public EventsUserController(DataContext context, IEventUserRepository eventUserRepository, IMapper mapper,
            IPhotoEventService photoEventService)
        {
            _context = context;
            _eventUserRepository = eventUserRepository;
            _mapper = mapper;
            _photoEventService = photoEventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventUserDto>>> GetEventsUserAsync()
        {
            var events = await _eventUserRepository.GetEventsUserAsync();

            var eventsToReturn = _mapper.Map<IEnumerable<EventUserDto>>(events);

            return Ok(eventsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventUserDto>> GetEventUserAsync(int id)
        {
            var specifiedEvent = await _eventUserRepository.GetEventUserAsync(id);
            
            return _mapper.Map<EventUserDto>(specifiedEvent);

            // return await _eventUserRepository.GetEventDtoUserAsync(id);

            // return await _userRepository.GetMemberAsync(username);

        }
        
        [HttpGet("specified/{name}", Name = "GetEventUser")]
        public async Task<ActionResult<EventUserDto>> GetEventUserByNameAsync(string name)
        {
            var specifiedEvent = await _eventUserRepository.GetEventUserByNameAsync(name);
            
            return _mapper.Map<EventUserDto>(specifiedEvent);
        }

        [HttpPost]
        public async Task<ActionResult<EventUserDto>> CreateEventUser(EventUserDto eventUserDto)
        {
            if (await UserEventExists(eventUserDto.Name))
                return BadRequest("Event name is taken");
            
            var newEventUser = new EventUser()
            {
                Name = eventUserDto.Name,
                Description = eventUserDto.Description,
                StartDate = eventUserDto.StartDate,
                EndDate = eventUserDto.EndDate,
                EventType = eventUserDto.EventType,
                WinnerPrize = eventUserDto.WinnerPrize,
                EventOrganiser = eventUserDto.EventOrganiser,
                GameId = eventUserDto.GameId,
                PhotoUrl = eventUserDto.PhotoUrl,
            };
            
            if (eventUserDto.StartDate > eventUserDto.EndDate)
                return BadRequest("The start date must not be later than the end date of the event");

            _eventUserRepository.AddEventUser(newEventUser);

            if (await _eventUserRepository.SaveAllAsync())
                return Ok(_mapper.Map<EventUserDto>(newEventUser));
            return BadRequest("Failed to add event for solo players");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEventUser(int id)
        {
            var specifiedEvent = await _eventUserRepository.GetEventUserAsync(id);

            if (DateTime.Now > specifiedEvent.StartDate && DateTime.Now < specifiedEvent.EndDate)
                return BadRequest("You cannot delete ongoing event for solo players");

            _eventUserRepository.DeleteEventUser(specifiedEvent);

            if (await _eventUserRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting event for solo players");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEventUser(EventUser specifiedEvent, int id)
        {
            var eventAsync = await _eventUserRepository.GetEventUserAsync(id);
            specifiedEvent.Name = Strings.Trim(specifiedEvent.Name);

            if (CompareEventUser(eventAsync, specifiedEvent))
            {
                return NoContent();
            }

            if (await UserEventExists(specifiedEvent.Name) && !eventAsync.Name.Equals(specifiedEvent.Name))
                return BadRequest("Event name is taken");

            eventAsync.EventUserId = eventAsync.EventUserId;
            if (specifiedEvent.Name != null)
                eventAsync.Name = specifiedEvent.Name;
            if (specifiedEvent.Description != null)
                eventAsync.Description = specifiedEvent.Description;
            if (specifiedEvent.StartDate != null)
                eventAsync.StartDate = specifiedEvent.StartDate;
            if (specifiedEvent.EndDate != null)
                eventAsync.EndDate = specifiedEvent.EndDate;
            if (specifiedEvent.EventType != null)
                eventAsync.EventType = specifiedEvent.EventType;
            if (specifiedEvent.WinnerPrize != null)
                eventAsync.WinnerPrize = specifiedEvent.WinnerPrize;
            if (specifiedEvent.GameId != null)
                eventAsync.GameId = specifiedEvent.GameId;
            if (specifiedEvent.EventOrganiser != null)
                eventAsync.EventOrganiser = specifiedEvent.EventOrganiser;
            if (specifiedEvent.PhotoUrl != null)
                eventAsync.PhotoUrl = specifiedEvent.PhotoUrl;

            if (await _eventUserRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update event");
        }

        [HttpPost("add-photo/{name}")]
        public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file, string name)
        {
            var specifiedEvent = await _eventUserRepository.GetEventUserByNameAsync(name);

            var result = await _photoEventService.AddPhotoAsync(file);

            if (result.Error != null)
                return BadRequest(result.Error.Message);

            var photo = new Photo()
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            specifiedEvent.PhotoUrl = photo.Url;

            if (await _eventUserRepository.SaveAllAsync())
            {
                return CreatedAtRoute("GetEventUser", new {name = specifiedEvent.Name} ,_mapper.Map<PhotoDto>(photo));
                // return _mapper.Map<PhotoDto>(photo);

            }
            return BadRequest("Problem occured when adding photo");
        }
        
        private async Task<bool> UserEventExists(string name)
        {
            return await _context.EventUser.AnyAsync(x => x.Name == name);
        }

        private bool CompareEventUser(EventUser firstEvent, EventUser secondEvent)
        {
            return ((firstEvent.EventOrganiser == secondEvent.EventOrganiser) &&
                    (firstEvent.Name == secondEvent.Name) &&
                    (firstEvent.StartDate == secondEvent.StartDate) &&
                    (firstEvent.EndDate == secondEvent.EndDate) &&
                    (firstEvent.GameId == secondEvent.GameId) &&
                    (firstEvent.EventType == secondEvent.EventType) &&
                    (firstEvent.WinnerPrize.Equals(secondEvent.WinnerPrize)));
        }
    }
}