using Microsoft.AspNetCore.Mvc;
using organizer_gracza_backend.Helpers;

namespace organizer_gracza_backend.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {

    }
}