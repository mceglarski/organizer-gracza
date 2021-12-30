using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Data;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Extensions;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    public class ForumPostController : BaseApiController
    {
        private readonly IForumPost _forumPost;
        private readonly IMapper _mapper;
        private readonly IUserAchievementCounterRepository _userAchievementCounterRepository;
        private readonly IUserAchievementRepository _userAchievementRepository;
        private readonly DataContext _context;
        private readonly IGeneralStatisticsRepository _generalStatisticsRepository;

        public ForumPostController(IForumPost forumPost, DataContext context,
            IMapper mapper, IUserAchievementCounterRepository userAchievementCounterRepository,
            IUserAchievementRepository userAchievementRepository,
            IGeneralStatisticsRepository generalStatisticsRepository)
        {
            _forumPost = forumPost;
            _mapper = mapper;
            _userAchievementCounterRepository = userAchievementCounterRepository;
            _userAchievementRepository = userAchievementRepository;
            _context = context;
            _generalStatisticsRepository = generalStatisticsRepository;
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

            if (!await _forumPost.SaveAllAsync())
                return BadRequest("Failed to add forum post");

            var userAchievement = await _userAchievementCounterRepository
                .GetUserAchievementCounterByUserId(forumPostDto.UserId);

            var generalStatistics = _generalStatisticsRepository
                .GetGeneralStatisticsByUserIdAsync(forumPostDto.UserId);

            generalStatistics.Result.PostWritten++;
            userAchievement.NumberOfPostsCreated++;
            
            if (!await _userAchievementCounterRepository.SaveAllAsync())
                return BadRequest("Failed to increase counter");

            var firstPostAchievement = await _userAchievementRepository
                .GetUserAchievementsForUserAndAchievementAsync(forumPostDto.UserId, 11);

            if (userAchievement.NumberOfPostsCreated == 1)
            {
                var newUserAchievement = new UserAchievement()
                {
                    UserId = forumPostDto.UserId,
                    AchievementsId = 11
                };
                
                _userAchievementRepository.AddUserAchievement(newUserAchievement);
                
                if (!await _userAchievementRepository.SaveAllAsync())
                    return BadRequest("Failed to add 'Wyraziłem swoją opinie' achievement");
            }
            
            if (userAchievement.NumberOfPostsCreated == 10)
            {
                var newUserAchievement = new UserAchievement()
                {
                    UserId = forumPostDto.UserId,
                    AchievementsId = 12
                };
                
                _userAchievementRepository.AddUserAchievement(newUserAchievement);
                
                if (!await _userAchievementRepository.SaveAllAsync())
                    return BadRequest("Failed to add 'Chętny do odpowiedzi' achievement");
            }
            
            if (userAchievement.NumberOfPostsCreated == 25)
            {
                var newUserAchievement = new UserAchievement()
                {
                    UserId = forumPostDto.UserId,
                    AchievementsId = 13
                };
                
                _userAchievementRepository.AddUserAchievement(newUserAchievement);
                
                if (!await _userAchievementRepository.SaveAllAsync())
                    return BadRequest("Failed to add 'Pomocna dłoń' achievement");
            }
            
            if (userAchievement.NumberOfPostsCreated == 100)
            {
                var newUserAchievement = new UserAchievement()
                {
                    UserId = forumPostDto.UserId,
                    AchievementsId = 14
                };
                
                _userAchievementRepository.AddUserAchievement(newUserAchievement);
                
                if (!await _userAchievementRepository.SaveAllAsync())
                    return BadRequest("Failed to add 'Najlepszy przyjaciel' achievement");
            }

            return Ok(_mapper.Map<ForumPostDto>(newForumPost));
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

            if (forumPost.Content != null)
                forumPostAsync.Content = forumPost.Content;

            if (await _forumPost.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update forum post");
        }
    }
}