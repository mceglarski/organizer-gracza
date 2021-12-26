using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    public class TwitchController : BaseApiController
    {
        private readonly IConfiguration _configuration;

        public TwitchController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        private string TokenValue => _configuration["TwitchSettings:TokenValue"];
        private string IdValue => _configuration["TwitchSettings:IdValue"];
        
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            using HttpClient twitch = new HttpClient();
            try
            {
                twitch.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", TokenValue);
                twitch.DefaultRequestHeaders.Add("Client-Id", IdValue);
                var response = await twitch.GetAsync("https://api.twitch.tv/helix/streams");
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<TwitchDataResponse>(result);

                return Ok(json);
            }
            catch (HttpRequestException e)
            {
                return BadRequest("Error getting twitch response" + e.StatusCode);
            }
        }
        
        [HttpGet("game/{id}")]
        public async Task<IActionResult> GetDataForGame(string id)
        {
            using HttpClient twitch = new HttpClient();
            try
            {
                twitch.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", TokenValue);
                twitch.DefaultRequestHeaders.Add("Client-Id", IdValue);
                var response = await twitch.GetAsync($"https://api.twitch.tv/helix/streams/?game_id={id}");
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<TwitchDataResponse>(result);

                return Ok(json);
            }
            catch (HttpRequestException e)
            {
                return BadRequest("Error getting twitch response" + e.StatusCode);
            }
        }
        
        [HttpGet("game/{gameId}/language/{languageId}")]
        public async Task<IActionResult> GetDataForGameAndLanguage(string gameId, string languageId)
        {
            using HttpClient twitch = new HttpClient();
            try
            {
                twitch.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", TokenValue);
                twitch.DefaultRequestHeaders.Add("Client-Id", IdValue);
                var response = await twitch.GetAsync($"https://api.twitch.tv/helix/streams/?game_id={gameId}&language={languageId}");
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<TwitchDataResponse>(result);

                return Ok(json);
            }
            catch (HttpRequestException e)
            {
                return BadRequest("Error getting twitch response" + e.StatusCode);
            }
        }
        
        [HttpGet("language/{id}")]
        public async Task<IActionResult> GetDataForLanguage(string id)
        {
            using HttpClient twitch = new HttpClient();
            try
            {
                twitch.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", TokenValue);
                twitch.DefaultRequestHeaders.Add("Client-Id", IdValue);
                var response = await twitch.GetAsync($"https://api.twitch.tv/helix/streams/?language={id}");
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<TwitchDataResponse>(result);

                return Ok(json);
            }
            catch (HttpRequestException e)
            {
                return BadRequest("Error getting twitch response" + e.StatusCode);
            }
        }
    }
}