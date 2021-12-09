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
    public class ArticlesController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IArticlesRepository _articlesRepository;
        private readonly IMapper _mapper;

        public ArticlesController(DataContext context, IArticlesRepository articlesRepository, IMapper mapper)
        {
            _context = context;
            _articlesRepository = articlesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articles>>> GetArticlesAsync()
        {
            var articles = await _articlesRepository.GetArticles();

            var articlesToReturn = _mapper.Map<IEnumerable<ArticlesDto>>(articles);

            return Ok(articlesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticlesDto>> GetArticle(int id)
        {
            var article = await _articlesRepository.GetArticleById(id);

            return _mapper.Map<ArticlesDto>(article);
        }

        [HttpGet("userId/{id}")]
        public async Task<ActionResult<IEnumerable<ArticlesDto>>> GetArticlesByUserId(int id)
        {
            var articles = await _articlesRepository.GetArticleByUserId(id);

            var articlesToReturn = _mapper.Map<IEnumerable<ArticlesDto>>(articles);

            return Ok(articlesToReturn);
        }

        [HttpGet("article/{articleId}/{userId}")]
        public async Task<ActionResult<ArticlesDto>> GetArticleForUser(int articleId, int userId)
        {
            var article = await _articlesRepository.GetArticleForUser(articleId, userId);

            return _mapper.Map<ArticlesDto>(article);
        }

        [HttpPost]
        public async Task<ActionResult<Articles>> CreateArticle(ArticlesDto articlesDto)
        {
            var newArticle = new Articles()
            {
                Title = articlesDto.Title,
                Content = articlesDto.Content,
                PublicationDate = articlesDto.PublicationDate,
                PhotoUrl = articlesDto.PhotoUrl,
                UserId = articlesDto.UserId
            };

            _articlesRepository.AddArticle(newArticle);

            if (await _articlesRepository.SaveAllAsync())
                return Ok(_mapper.Map<ArticlesDto>(newArticle));
            return BadRequest("Failed to add article");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArticle(int id)
        {
            var article = await _articlesRepository.GetArticleById(id);

            _articlesRepository.DeleteArticle(article);

            if (await _articlesRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting article");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateArticle(Articles articles, int id)
        {
            var articlesAsync = await _articlesRepository.GetArticleById(id);

            articlesAsync.ArticlesId = articles.ArticlesId;
            if (articles.Title != null)
                articlesAsync.Title = articles.Title;
            if (articles.Content != null)
                articlesAsync.Content = articles.Content;
            if (articles.PublicationDate != null)
                articlesAsync.PublicationDate = articles.PublicationDate;
            if (articles.PhotoUrl != null)
                articlesAsync.PhotoUrl = articles.PhotoUrl;
            if (articles.UserId != null)
                articlesAsync.UserId = articles.UserId;

            if (await _articlesRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update article");
        }
    }
}