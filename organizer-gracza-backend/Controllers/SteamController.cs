using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using organizer_gracza_backend.Helpers;
using organizer_gracza_backend.Model;


namespace organizer_gracza_backend.Controllers
{
    public class SteamController : BaseApiController
    {
        private readonly IConfiguration _configuration;

        public SteamController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        private string API_Key => _configuration["SteamSettings:API_Key"];
        private string API_Uri => _configuration["SteamSettings:API_Uri"];
        
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            
            using HttpClient steam = new HttpClient();
            try
            {
                steam.BaseAddress = new Uri(API_Uri);
                var response = await steam.GetAsync($"/ISteamUser/GetPlayerSummaries/v0002/?key={API_Key}&steamids={id}");
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<SteamUserResponse>(result);

                return Ok(json);
            }
            catch (HttpRequestException e)
            {
                return BadRequest($"Error getting user {id}: {e.Message}");
            }
        }
        
        [HttpGet("user/friends/{id}")]
        public async Task<IActionResult> GetUserFriends(string id)
        {
            using HttpClient steam = new HttpClient();
            try
            {
                steam.BaseAddress = new Uri(API_Uri);
                var response = await steam.GetAsync($"ISteamUser/GetFriendList/v0001/?key={API_Key}&steamid={id}&relationship=friend");
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<SteamUserFriendsResponse>(result);

                return Ok(json);
            }
            catch (HttpRequestException e)
            {
                return BadRequest($"Error getting user {id}: {e.Message}");
            }
        }
        
        [HttpGet("user/games/{id}")]
        public async Task<IActionResult> GetUserGames(string id)
        {
            using HttpClient steam = new HttpClient();
            try
            {
                steam.BaseAddress = new Uri(API_Uri);
                var response = await steam.GetAsync($"IPlayerService/GetOwnedGames/v0001/?key={API_Key}&steamid={id}");
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<SteamUserGamesResponse>(result);

                return Ok(json);
            }
            catch (HttpRequestException e)
            {
                return BadRequest($"Error getting user {id}: {e.Message}");
            }
        }
        
        [HttpGet("news/{gameId}")]
        public async Task<IActionResult> GetNewsForGame(int gameId)
        {
            using HttpClient steam = new HttpClient();
            try
            {
                steam.BaseAddress = new Uri(API_Uri);
                var response = await steam.GetAsync($"/ISteamNews/GetNewsForApp/v0002/?appid={gameId}&count=100");
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<SteamNewsResponse>(result);

                return Ok(json);
            }
            catch (HttpRequestException e)
            {
                return BadRequest($"Error getting news for game {gameId}: {e.Message}");
            }
        }
        
        [HttpGet("achievements/{gameId}")]
        public async Task<IActionResult> GetAchievements(int gameId)
        {
            using HttpClient steam = new HttpClient();
            try
            {
                steam.BaseAddress = new Uri(API_Uri);
                var response = await steam.GetAsync($"/ISteamUserStats/GetGlobalAchievementPercentagesForApp/v0002/?gameid={gameId}");
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<SteamAchievementResponse>(result);

                return Ok(json);
            }
            catch (HttpRequestException e)
            {
                return BadRequest($"Error getting achievements for game {gameId}: {e.Message}");
            }
        }
        
        [HttpGet("achievements/details/{gameId}")]
        public async Task<IActionResult> GetAchievementDetails(int gameId)
        {
            using HttpClient steam = new HttpClient();
            try
            {
                steam.BaseAddress = new Uri(API_Uri);
                var response = await steam.GetAsync($"/ISteamUserStats/GetSchemaForGame/v2/?key={API_Key}&appid={gameId}");
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<SteamAchievementDetailResponse>(result);

                return Ok(json);
            }
            catch (HttpRequestException e)
            {
                return BadRequest($"Error getting achievements for game {gameId}: {e.Message}");
            }
        }
        
        [HttpGet("user/achievements/{userId}/game/{gameId}")]
        public async Task<IActionResult> GetUserAchievements(string userId, int gameId)
        {
            using HttpClient steam = new HttpClient();
            try
            {
                steam.BaseAddress = new Uri(API_Uri);
                var response = await steam.GetAsync($"/ISteamUserStats/GetPlayerAchievements/v0001/?appid={gameId}&key={API_Key}&steamid={userId}");
                response.EnsureSuccessStatusCode();
        
                
                
                string result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<SteamUserAchievementResponse>(result);
        
                return Ok(json);
            }
            catch (HttpRequestException e)
            {
                return BadRequest($"Error getting achievements for game {userId}: {e.Message}");
            }
        }
        
        [HttpGet("user/played/{userId}")]
        public async Task<IActionResult> GetUserAchievements(string userId)
        {
            using HttpClient steam = new HttpClient();
            try
            {
                steam.BaseAddress = new Uri(API_Uri);
                var response = await steam.GetAsync($"/IPlayerService/GetRecentlyPlayedGames/v0001/?key={API_Key}&steamid={userId}&format=json");
                response.EnsureSuccessStatusCode();
        
                
                
                string result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<SteamRecentlyPlayedResponse>(result);
        
                return Ok(json);
            }
            catch (HttpRequestException e)
            {
                return BadRequest($"Error getting achievements for game {userId}: {e.Message}");
            }
        }
    }
}