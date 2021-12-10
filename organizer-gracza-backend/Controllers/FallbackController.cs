using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace organizer_gracza_backend.Controllers
{
    public class FallbackController : Controller
    {

        public ActionResult Index()
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), 
                "wwwroot", "index.html"), "text/HTML");
        }
        
    }
}