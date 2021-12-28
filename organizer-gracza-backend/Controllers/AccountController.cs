using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using organizer_gracza_backend.Data;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;
using SendGrid;
using SendGrid.Helpers.Mail;
using User = organizer_gracza_backend.Model.User;


namespace organizer_gracza_backend.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;
        private readonly IUserAchievementCounterRepository _userAchievementCounterRepository;
        private readonly IPhotoService _photoService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            ITokenService tokenService, IMapper mapper, IConfiguration configuration, DataContext context,
            IUserAchievementCounterRepository userAchievementCounterRepository, IPhotoService photoService)
        {
            _tokenService = tokenService;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context;
            _userAchievementCounterRepository = userAchievementCounterRepository;
            _photoService = photoService;
        }
        
        private string API_Key => _configuration["SendGrid:API_Key"];

        
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            registerDto.Username = Strings.Trim(registerDto.Username);
            registerDto.Nickname = Strings.Trim(registerDto.Nickname);
            registerDto.Email = Strings.Trim(registerDto.Email);

            if (await UsernameExists(registerDto.Username))
                return BadRequest("Username is taken");

            if (await NicknameExists(registerDto.Nickname))
                return BadRequest("Nickname is taken");
            
            if (await NicknameExistsToLower(registerDto.Nickname.ToLower()))
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
            
            var client = new SendGridClient(API_Key);
            var from = new EmailAddress("organizergracza@gmail.com", "Organizer gracza");
            var subject = "Potwierdzenie adresu E-mail";
            var to = new EmailAddress(user.Email, user.UserName);
            var plainTextContent = "Dzień dobry, dziękujemy za zarejestrowanie się na naszej stronie Organizer Gracza. Prosimy wejść na link wysłany w wiadomości w celu potwierdzenia swojego adresu E-mail. Link do potwierdzenia: https://organizer-gracza.herokuapp.com/activate-email";
            var htmlContent = "Dzień dobry, dziękujemy za zarejestrowanie się na naszej stronie Organizer Gracza. Prosimy wejść na link wysłany w wiadomości w celu potwierdzenia swojego adresu E-mail. Link do potwierdzenia: https://organizer-gracza.herokuapp.com/activate-email";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            if (!response.IsSuccessStatusCode)
                BadRequest("Nie udało się wysłać wiadomości z linkiem do potwierdzenia E-mailu.");

            var userAchievementCounter = new UserAchievementCounter()
            {
                NumberOfPostsCreated = 0,
                NumberOfTeamsCreated = 0,
                NumberOfTeamsJoined = 0,
                NumberOfThreadsCreated = 0,
                NumberOfEventUserJoined = 0,
                UserId = user.Id
            };

            _context.UserAchievementCounters.Add(userAchievementCounter);
            
            if (!await _userAchievementCounterRepository.SaveAllAsync())
                return BadRequest("Failed to add counter for user");

            var photo = new Photo()
            {
                Url = "https://cdn1.iconfinder.com/data/icons/game-design-butterscotch-vol-1/256/Gamer-512.png",
                UserId = user.Id,
                IsMain = true
            };

            _context.Photos.Add(photo);
            if (!await _photoService.SaveAllAsync())
                return BadRequest("Failed to save photo");

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
            return await _userManager.Users.AnyAsync(x => x.UserName.Equals(username.ToLower()));
        }
        
        private async Task<bool> NicknameExists(string nickname)
        {

            return await _userManager.Users.AnyAsync(x => x.Nickname.Equals(nickname));
        }
        
        private async Task<bool> NicknameExistsToLower(string nickname)
        {
            return await _userManager.Users.AnyAsync(x => x.Nickname.ToLower().Equals(nickname.ToLower()));
        }

        private async Task<bool> EmailExists(string email)
        {
            return await _userManager.Users.AnyAsync(x => x.Email.Equals(email.ToLower()));
        }
    }
}