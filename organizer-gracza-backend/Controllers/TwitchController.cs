using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Controllers
{
    public class TwitchController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            using HttpClient twitch = new HttpClient();
            try
            {
                twitch.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", "wh6c1oa2kkqp33h1bjziw93no30761");
                twitch.DefaultRequestHeaders.Add("Client-Id", "gp762nuuoqcoxypju8c569th9wz7q5");
                var response = await twitch.GetAsync("https://api.twitch.tv/helix/streams");
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject(result);

                return Ok(json);
            }
            catch (HttpRequestException e)
            {
                return BadRequest("Error getting twitch response" + e.StatusCode);
            }
        }
    }
}