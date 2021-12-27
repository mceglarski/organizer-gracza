using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using organizer_gracza_backend.Data;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Extensions;
using organizer_gracza_backend.Helpers;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;
using SendGrid;
using SendGrid.Helpers.Mail;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace organizer_gracza_backend.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public UsersController(IUserRepository userRepository, IMapper mapper, IPhotoService photoService,
            UserManager<User> userManager, IConfiguration configuration, DataContext context)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _photoService = photoService;
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
        }

        private string API_Key => _configuration["SendGrid:API_Key"];

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers([FromQuery] PaginationParams paginationParams)
        {
            var users = await _userRepository.GetMembersAsync(paginationParams);

            Response.AddPaginationHeader(users.CurrentPage, users.PageSize,
                users.TotalCount, users.TotalPages);

            return Ok(users);
        }

        [AllowAnonymous]
        [HttpGet("user/{username}")]
        public int GetUserId(string username)
        {
            var query = _userRepository.GetUserByUsernameAsync(username);

            return query.Result.Id;
        }

        [HttpGet("member")]
        public int GetCurrentlyLoggedMemberId()
        {
            var query = _userRepository.GetUserByUsernameAsync(User.GetUsername());

            return query.Result.Id;
        }

        [AllowAnonymous]
        [HttpGet("{username}", Name = "GetUser")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await _userRepository.GetMemberAsync(username);
        }

        [AllowAnonymous]
        [HttpGet("member/{id}")]
        public async Task<ActionResult<MemberDto>> GetUserById(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            memberUpdateDto.Nickname = Strings.Trim(memberUpdateDto.Nickname);
            memberUpdateDto.SteamId = Strings.Trim(memberUpdateDto.SteamId);

            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            if (IsValidSteamid(memberUpdateDto.SteamId) == false)
                return BadRequest("SteamId is in incorrect format");

            _mapper.Map(memberUpdateDto, user);

            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Failed to update user");
        }

        [HttpPut("email")]
        public async Task<ActionResult> SetEmailConfirmed(MemberUpdateDto memberUpdateDto)
        {
            memberUpdateDto.Nickname = Strings.Trim(memberUpdateDto.Nickname);
            memberUpdateDto.SteamId = Strings.Trim(memberUpdateDto.SteamId);

            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            if (IsValidSteamid(memberUpdateDto.SteamId) == false)
                return BadRequest("SteamId is in incorrect format");

            _mapper.Map(memberUpdateDto, user);

            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Email confirmed failed");
        }


        [HttpPut("password")]
        public async Task<ActionResult> ChangePassword(MemberUpdateDto memberUpdateDto)
        {
            memberUpdateDto.Nickname = Strings.Trim(memberUpdateDto.Nickname);
            memberUpdateDto.SteamId = Strings.Trim(memberUpdateDto.SteamId);

            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            if (IsValidSteamid(memberUpdateDto.SteamId) == false)
                return BadRequest("SteamId is in incorrect format");

            var currentUser = _userRepository.GetUserByUsernameAsync(User.GetUsername()).Result;

            await _userManager.RemovePasswordAsync(currentUser);
            await _userManager.AddPasswordAsync(currentUser, memberUpdateDto.NewPassword);

            _mapper.Map(memberUpdateDto, user);

            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("password failed");
        }


        [HttpGet("resetpassword")]
        public async Task<ActionResult> ForgotPassword(MemberUpdateDto memberUpdateDto, string email)
        {
            memberUpdateDto.Nickname = Strings.Trim(memberUpdateDto.Nickname);
            memberUpdateDto.SteamId = Strings.Trim(memberUpdateDto.SteamId);

            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            if (IsValidSteamid(memberUpdateDto.SteamId) == false)
                return BadRequest("SteamId is in incorrect format");

            await SendForgotPasswordLink(email);

            var currentUser = _userRepository.GetUserByUsernameAsync(User.GetUsername()).Result;

            await _userManager.RemovePasswordAsync(currentUser);
            await _userManager.AddPasswordAsync(currentUser, memberUpdateDto.NewPassword);

            _mapper.Map(memberUpdateDto, user);

            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("password failed");
        }
        
        [AllowAnonymous]
        [HttpGet("sendlink/{email}")]
        public async Task<ActionResult<UserDto>> SendForgotPasswordLink(string email)
        {
            if (await EmailExists(email))
            {
                var stamp = _userManager.FindByEmailAsync(email.ToLower());

                var client = new SendGridClient(API_Key);
                var from = new EmailAddress("organizergracza@gmail.com", "Organizer Gracza");
                var subject = "Link do zresetowania hasła";
                var to = new EmailAddress(email, "Użytkownik");
                var plainTextContent =
                    "Dzień dobry, w celu zresetowania hasła dla swojego konta proszę wejść w link. Link do zresetowania: https://organizer-gracza.herokuapp.com/resetpassword/" +
                    stamp.Result.SecurityStamp;
                var htmlContent =
                    "Dzień dobry, w celu zresetowania hasła dla swojego konta proszę wejść w link. Link do zresetowania: https://organizer-gracza.herokuapp.com/resetpassword/" +
                    stamp.Result.SecurityStamp;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
                if (!response.IsSuccessStatusCode)
                    BadRequest("Nie udało się wysłać wiadomości w celu zresetowania hasła.");
                return Ok("Link has been sent");
            }

            return BadRequest("Link has not been sent");
        }
        
        [AllowAnonymous]
        [HttpPut("resetpassword/{newPassword}/{stamp}")]
        public async Task<ActionResult<User>> ChangeForgottenPassword(string newPassword, string stamp)
        {
            if (await StampExists(stamp))
                return BadRequest("Password change failed");

            var user = _context.Users.SingleAsync(x => x.SecurityStamp.ToLower().Equals(stamp.ToLower())).Result;
            
            await _userManager.RemovePasswordAsync(user);
            await _userManager.AddPasswordAsync(user, newPassword); ;

            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync())
                return NoContent();
            return BadRequest("Password change failed");
        }

        [HttpPost("add-photo")]
        public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null)
                return BadRequest(result.Error.Message);

            var photo = new Photo()
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            if (user.Photos.Count == 0)
            {
                photo.IsMain = true;
            }

            user.Photos.Add(photo);

            if (await _userRepository.SaveAllAsync())
            {
                return CreatedAtRoute("GetUser", new { username = user.UserName },
                    _mapper.Map<PhotoDto>(photo));
            }

            return BadRequest("Problem adding photo");
        }

        [HttpPost("add-photo-article")]
        public async Task<ActionResult<PhotoDto>> AddArticlePhoto(IFormFile file)
        {
            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null)
                return BadRequest(result.Error.Message);

            var photo = new Photo()
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            return _mapper.Map<PhotoDto>(photo);
        }

        [HttpPut("set-main-photo/{photoId}")]
        public async Task<ActionResult> SetMainPhoto(int photoId)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            var photo = user.Photos.FirstOrDefault(x => x.PhotoId == photoId);

            if (photo.IsMain)
                return BadRequest("This is already your main photo");

            var currentMain = user.Photos.FirstOrDefault(x => x.IsMain);
            if (currentMain != null)
                currentMain.IsMain = false;
            photo.IsMain = true;

            if (await _userRepository.SaveAllAsync())
                return NoContent();

            return BadRequest("Failed to set main photo");
        }

        [HttpDelete("delete-photo/{photoId}")]
        public async Task<ActionResult> DeletePhoto(int photoId)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            var photo = user.Photos.FirstOrDefault(x => x.PhotoId == photoId);

            if (photo == null)
                return NotFound();
            if (photo.IsMain)
                return BadRequest("You cannot delete your main photo");
            if (photo.PublicId != null)
            {
                var result = await _photoService.DeletePhotoAsync(photo.PublicId);
                if (result.Error != null)
                    return BadRequest(result.Error.Message);
            }

            user.Photos.Remove(photo);

            if (await _userRepository.SaveAllAsync())
                return Ok();

            return BadRequest("Failed to delete photo");
        }

        public bool IsValidSteamid(string id)
        {
            var array = id.ToCharArray();
            foreach (var item in array)
            {
                if (!char.IsDigit(item))
                    return false;
            }

            return true;
        }

        private async Task<bool> EmailExists(string email)
        {
            return await _userManager.Users.AnyAsync(x => x.Email.ToLower().Equals(email.ToLower()));
        }
        
        private async Task<bool> StampExists(string stamp)
        {
            return await _userManager.Users.AnyAsync(x => x.SecurityStamp.ToLower().Equals(stamp.ToLower()));
        }
    }
}