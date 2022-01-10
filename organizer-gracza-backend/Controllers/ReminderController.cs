using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    public class ReminderController : BaseApiController
    {
        private readonly IReminderRepository _reminderRepository;
        private readonly IMapper _mapper;

        public ReminderController(IReminderRepository reminderRepository, IMapper mapper)
        {
            _reminderRepository = reminderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReminderDto>>> GetRemindersAsync()
        {
            var reminds = await _reminderRepository.GetReminders();

            var remindsToReturn = _mapper.Map<IEnumerable<ReminderDto>>(reminds);

            return Ok(remindsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReminderDto>> GetRemind(int id)
        {
            var remind = await _reminderRepository.GetReminderById(id);
            
            return _mapper.Map<ReminderDto>(remind);
        }
        
        [HttpGet("userId/{id}")]
        public async Task<ActionResult<IEnumerable<ReminderDto>>> GetRemindersForUserById(int id)
        {
            var reminds = await _reminderRepository.GetRemindersForUserById(id);

            var remindsToReturn = _mapper.Map<IEnumerable<ReminderDto>>(reminds);

            return Ok(remindsToReturn);
        }
        
        [HttpGet("remind/{reminderId}/{userId}")]
        public async Task<ActionResult<ReminderDto>> GetRemindersForUserById(int reminderId, int userId)
        {
            var remind = await _reminderRepository.GetReminderForUser(reminderId, userId);

            return _mapper.Map<ReminderDto>(remind);
        }
        
        [HttpPost]
        public async Task<ActionResult<ReminderDto>> CreateRemind(ReminderDto reminderDto)
        {
            var newReminder = new Reminder()
            {
                Title = reminderDto.Title,
                StartDate = reminderDto.StartDate,
                UserId = reminderDto.UserId
            };

            _reminderRepository.AddReminder(newReminder);

            if (await _reminderRepository.SaveAllAsync())
                return Ok(_mapper.Map<ReminderDto>(newReminder));
            return BadRequest("Failed to add remind");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRemind(int id)
        {
            var remind = await _reminderRepository.GetReminderById(id);

            _reminderRepository.DeleteReminder(remind);

            if (await _reminderRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting remind");
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReminder(Reminder reminder, int id)
        {
            var reminderAsync = await _reminderRepository.GetReminderById(id);

            if (reminder.Title != null)
                reminderAsync.Title = reminder.Title;
            if (reminder.StartDate != null)
                reminderAsync.StartDate = reminder.StartDate;

            if (await _reminderRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update reminder");
        }
    }
}