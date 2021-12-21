using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    public class ForumPostController : BaseApiController
    {
        private readonly IForumPost _forumPost;
        private readonly IForumThread _forumThread;
        private readonly IMapper _mapper;

        public ForumPostController(IForumPost forumPost,
            IMapper mapper, IForumThread forumThread)
        {
            _forumPost = forumPost;
            _mapper = mapper;
            _forumThread = forumThread;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ForumPostDto>>> GetForumPostAsync()
        {
            var forumPost = await _forumPost.GetForumPostsAsync();

            var forumPostToReturn = _mapper.Map<IEnumerable<ForumPostDto>>(forumPost);

            return Ok(forumPostToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ForumPostDto>> GetForumPostAsync(int id)
        {
            var forumPost = await _forumPost.GetForumPostAsync(id);

            return _mapper.Map<ForumPostDto>(forumPost);
        }

        [HttpGet("userId/{id}")]
        public async Task<ActionResult<IEnumerable<ForumPostDto>>> GetForumPostByUserIdAsync(int id)
        {
            var forumPost = await _forumPost.GetForumPostByUserId(id);

            var forumPostToReturn = _mapper.Map<IEnumerable<ForumPostDto>>(forumPost);

            return Ok(forumPostToReturn);
        }
        
        [HttpPost]
        public async Task<ActionResult<ForumPostDto>> CreateForumPost(ForumPostDto forumPostDto)
        {
            var newForumPost = new ForumPost()
            {
                Content = forumPostDto.Content,
                PostDate = forumPostDto.PostDate,
                UserId = forumPostDto.UserId,
                ForumThreadId = forumPostDto.ForumThreadId
            };
            
            _forumPost.AddForumPost(newForumPost);

            if (await _forumPost.SaveAllAsync())
                return Ok(_mapper.Map<ForumPostDto>(newForumPost));
            return BadRequest("Failed to add forum post");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteForumPost(int id)
        {
            var forumPost = await _forumPost.GetForumPostAsync(id);

            _forumPost.DeleteForumPost(forumPost);

            if (await _forumPost.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting forum post");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateForumPost(ForumPost forumPost, int id)
        {
            var forumPostAsync = await _forumPost.GetForumPostAsync(id);

            forumPostAsync.ForumThreadId = forumPostAsync.ForumThreadId;

            if (forumPost.Content != null)
                forumPostAsync.Content = forumPost.Content;
            if (forumPost.PostDate != null)
                forumPostAsync.PostDate = forumPost.PostDate;

            if (await _forumPost.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update forum post");
        }
    }
}