using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    public class ForumThreadController : BaseApiController
    {
        private readonly IForumThread _forumThread;
        private readonly IMapper _mapper;

        public ForumThreadController(IForumThread forumThread,
            IMapper mapper)
        {
            _forumThread = forumThread;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ForumThreadDto>>> GetForumThreadsAsync()
        {
            var forumThreads = await _forumThread.GetForumThreadsAsync();

            var forumThreadsToReturn = _mapper.Map<IEnumerable<ForumThreadDto>>(forumThreads);

            return Ok(forumThreadsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ForumThreadDto>> GetForumThreadAsync(int id)
        {
            var forumThread = await _forumThread.GetForumThreadAsync(id);

            return _mapper.Map<ForumThreadDto>(forumThread);
        }

        [HttpGet("userId/{id}")]
        public async Task<ActionResult<IEnumerable<ForumThreadDto>>> GetForumThreadsByUserIdAsync(int id)
        {
            var forumThreads = await _forumThread.GetForumThreadsByUserId(id);

            var forumThreadsToReturn = _mapper.Map<IEnumerable<ForumThreadDto>>(forumThreads);

            return Ok(forumThreadsToReturn);
        }
        
        [HttpPost]
        public async Task<ActionResult<GameStatisticsDto>> CreateForumThread(ForumThreadDto forumThreadDto)
        {
            var newForumThread = new ForumThread()
            {
                Title = forumThreadDto.Title,
                Content = forumThreadDto.Content,
                ThreadDate = forumThreadDto.ThreadDate,
                GameId = forumThreadDto.GameId,
                UserId = forumThreadDto.UserId
            };

            _forumThread.AddForumThread(newForumThread);

            if (await _forumThread.SaveAllAsync())
                return Ok(_mapper.Map<ForumThreadDto>(newForumThread));
            return BadRequest("Failed to add forum thread");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteForumThread(int id)
        {
            var forumThread = await _forumThread.GetForumThreadAsync(id);

            _forumThread.DeleteForumThread(forumThread);

            if (await _forumThread.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting forum thread");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateForumThread(ForumThread forumThread, int id)
        {
            var forumThreadAsync = await _forumThread.GetForumThreadAsync(id);

            forumThreadAsync.ForumThreadId = forumThreadAsync.ForumThreadId;
            if (forumThread.Title != null)
                forumThreadAsync.Title = forumThread.Title;
            if (forumThread.Content != null)
                forumThreadAsync.Content = forumThread.Content;
            if (forumThread.ThreadDate != null)
                forumThreadAsync.ThreadDate = forumThread.ThreadDate;

            if (await _forumThread.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update forum thread");
        }
    }
}