using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CubedController : Controller
    {
        [TempData]
        public string? Value { get; set; }

        [TempData]
        public string? Result { get; set; }

        public IActionResult Index()
        {
            return View("Cubed");
        }

        public IActionResult Cube(double num)
        {
            Value = num.ToString();

            Result = Math.Pow(num, 3).ToString();

            return RedirectToAction(nameof(Index));
        }
    }
}