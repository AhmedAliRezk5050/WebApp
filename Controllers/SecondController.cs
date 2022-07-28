using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index()
        {
            return View("/Views/Shared/Common.cshtml");
        }
    }
} 