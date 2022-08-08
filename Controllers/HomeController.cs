using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
                return View(
               "Message",
               "This is the Index action on the Home controller");
        }

        public IActionResult Secure()
        {
                return View("Message",
                "This is the Secure action on the Home controller");
        }
    }
}