using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using organizer_gracza_backend.Data;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    public class GamesController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GamesController(DataContext context, IGameRepository gameRepository, IMapper mapper)
        {
            _context = context;
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGameAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult<GameDto>> CreateEvent(GameDto gameDto)
        {
            gameDto.Title = Strings.Trim(gameDto.Title);

            var newGame = new Game()
            {
                GameId = gameDto.GameId,
                Title = gameDto.Title,
                PhotoUrl = gameDto.PhotoUrl
            };
            
            if (await TitleExists(gameDto.Title))
                return BadRequest("Title is already taken");
            
            if (await TitleExistsToLower(gameDto.Title.ToLower()))
                return BadRequest("Title is already taken");

            _gameRepository.AddGame(newGame);

            if (await _gameRepository.SaveAllAsync())
                return Ok(_mapper.Map<GameDto>(newGame));
            return BadRequest("Failed to add game");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGame(int id)
        {
            var game = await _gameRepository.GetGameAsync(id);

            _gameRepository.DeleteGame(game);

            if (await _gameRepository.SaveAllAsync())
                return Ok();

            return BadRequest("An error occurred while deleting game");
        }
        
        private async Task<bool> TitleExists(string title)
        {

            return await _context.Games.AnyAsync(x => x.Title.Equals(title));
        }
        
        private async Task<bool> TitleExistsToLower(string title)
        {
            return await _context.Games.AnyAsync(x => x.Title.ToLower().Equals(title.ToLower()));
        }
    }
}