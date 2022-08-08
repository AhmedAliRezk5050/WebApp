using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(Request.IsHttps)
            {
                return View(
               "Message",
               "This is the Index action on the Home controller");
            } 

            return new StatusCodeResult(StatusCodes.Status403Forbidden);
           
        }
    }
}