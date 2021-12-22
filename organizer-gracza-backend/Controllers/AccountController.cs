using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, 
            ITokenService tokenService, IMapper mapper)
        {
            _tokenService = tokenService;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UsernameExists(registerDto.Username))
                return BadRequest("Username is taken");

            if (await NicknameExists(registerDto.Nickname))
                return BadRequest("Nickname is taken");

            if (await EmailExists(registerDto.Email))
                return BadRequest("Email is taken");
            
            var user = _mapper.Map<User>(registerDto);
            
            user.UserName = registerDto.Username.ToLower();
            user.Nickname = registerDto.Nickname;
            user.Email = registerDto.Email;

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Użytkownik");

            if (!roleResult.Succeeded)
                return BadRequest(result.Errors);
            
            return new UserDto()
            {
                Id = user.Id,
                Username = user.UserName,
                Nickname = user.Nickname,
                Token = await _tokenService.CreateToken(user),
                PhotoUrl = "https://cdn1.iconfinder.com/data/icons/game-design-butterscotch-vol-1/256/Gamer-512.png"
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

            if (user == null)
                return Unauthorized("Invalid nickname");

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                return Unauthorized();
            
            return new UserDto()
            {
                Id = user.Id,
                Username = user.UserName,
                Nickname = user.Nickname,
                Token = await _tokenService.CreateToken(user),
                PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain)?.Url
            };
        }

        private async Task<bool> UsernameExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
        
        private async Task<bool> NicknameExists(string nickname)
        {
            return await _userManager.Users.AnyAsync(x => x.Nickname == nickname.ToLower());
        }

        private async Task<bool> EmailExists(string email)
        {
            return await _userManager.Users.AnyAsync(x => x.Email == email.ToLower());
        }
    }
}