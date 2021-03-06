using System;
using System.Collections.Generic;
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
    public class EventsTeamController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IEventTeamRepository _eventTeamRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoEventService _photoEventService;

        public EventsTeamController(DataContext context, IEventTeamRepository eventTeamRepository, IMapper mapper,
            IPhotoEventService photoEventService)
        {
            _context = context;
            _eventTeamRepository = eventTeamRepository;
            _mapper = mapper;
            _photoEventService = photoEventService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventTeamDto>>> GetEventsTeamAsync()
        {
            var events = await _eventTeamRepository.GetEventsTeamAsync();

            var eventsToReturn = _mapper.Map<IEnumerable<EventTeamDto>>(events);

            return Ok(eventsToReturn);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<EventTeamDto>> GetEventTeamAsync(int id)
        {
            var specifiedEvent = await _eventTeamRepository.GetEventTeamAsync(id);

            return _mapper.Map<EventTeamDto>(specifiedEvent);
        }

        [AllowAnonymous]
        [HttpGet("specified/{name}", Name = "GetEventTeam")]
        public async Task<ActionResult<EventTeamDto>> GetEventTeamByNameAsync(string name)
        {
            var specifiedEvent = await _eventTeamRepository.GetEventTeamByNameAsync(name);

            return _mapper.Map<EventTeamDto>(specifiedEvent);
        }

        [HttpPost]
        public async Task<ActionResult<EventTeamDto>> CreateEventTeam(EventTeamDto eventTeamDto)
        {
            eventTeamDto.Name = Strings.Trim(eventTeamDto.Name);


            if (await NameExists(eventTeamDto.Name))
                return BadRequest("Name is already taken");

            if (await NameExistsToLower(eventTeamDto.Name.ToLower()))
                return BadRequest("Name is already taken");

            var newEventUser = new EventTeam()
            {
                Name = eventTeamDto.Name,
                Description = eventTeamDto.Description,
                StartDate = eventTeamDto.StartDate,
                EndDate = eventTeamDto.EndDate,
                EventType = eventTeamDto.EventType,
                WinnerPrize = eventTeamDto.WinnerPrize,
                EventOrganiser = eventTeamDto.EventOrganiser,
                GameId = eventTeamDto.GameId,
                PhotoUrl = eventTeamDto.PhotoUrl,
                EventTeamResultId = eventTeamDto.EventResultId,
            };

            if (eventTeamDto.StartDate > eventTeamDto.EndDate)
                return BadRequest("The start date must not be later than the end date of the event");

            _eventTeamRepository.AddEventTeam(newEventUser);

            if (await _eventTeamRepository.SaveAllAsync())
                return Ok(_mapper.Map<EventTeamDto>(newEventUser));
            return BadRequest("Failed to add event for teams");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEventTeam(int id)
        {
            var specifiedEvent = await _eventTeamRepository.GetEventTeamAsync(id);

            if (DateTime.Now > specifiedEvent.StartDate && DateTime.Now < specifiedEvent.EndDate)
                return BadRequest("You cannot delete ongoing event for teams");

            _eventTeamRepository.DeleteEventTeam(specifiedEvent);

            if (await _eventTeamRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting event for teams");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEventTeam(EventTeam specifiedEvent, int id)
        {
            var eventAsync = await _eventTeamRepository.GetEventTeamAsync(id);
            specifiedEvent.Name = Strings.Trim(specifiedEvent.Name);

            if (CompareEventTeam(eventAsync, specifiedEvent))
            {
                return NoContent();
            }

            if (await NameExists(specifiedEvent.Name) && !eventAsync.Name.Equals(specifiedEvent.Name))
                return BadRequest("Event name is taken");

            eventAsync.EventTeamId = eventAsync.EventTeamId;
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
            eventAsync.GameId = specifiedEvent.GameId;
            if (specifiedEvent.EventOrganiser != null)
                eventAsync.EventOrganiser = specifiedEvent.EventOrganiser;
            if (specifiedEvent.PhotoUrl != null)
                eventAsync.PhotoUrl = specifiedEvent.PhotoUrl;

            if (await _eventTeamRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update event");
        }

        [HttpPost("add-photo/{name}")]
        public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file, string name)
        {
            var specifiedEvent = await _eventTeamRepository.GetEventTeamByNameAsync(name);

            var result = await _photoEventService.AddPhotoAsync(file);

            if (result.Error != null)
                return BadRequest(result.Error.Message);

            var photo = new Photo()
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            specifiedEvent.PhotoUrl = photo.Url;

            if (await _eventTeamRepository.SaveAllAsync())
            {
                return CreatedAtRoute("GetEventTeam", new { name = specifiedEvent.Name }, _mapper.Map<PhotoDto>(photo));
                // return _mapper.Map<PhotoDto>(photo);
            }

            return BadRequest("Problem occured when adding photo");
        }

        private async Task<bool> NameExists(string name)
        {
            return await _context.EventTeam.AnyAsync(x => x.Name.Equals(name));
        }

        private async Task<bool> NameExistsToLower(string name)
        {
            return await _context.EventTeam.AnyAsync(x => x.Name.ToLower().Equals(name.ToLower()));
        }

        private bool CompareEventTeam(EventTeam firstEvent, EventTeam secondEvent)
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