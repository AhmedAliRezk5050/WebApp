using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private DataContext context;

        public HomeController(DataContext ctx)
        {
            context = ctx;
        }

        public async Task<IActionResult> Index(long id = 1)
        {
            ViewBag.AveragePrice = await context.Products.AverageAsync(p => p.Price);

            Product? product = await context.Products.FindAsync(id);

            if (product?.CategoryId == 1)
            {
                return View("Watersports", product);
            }
            else
            {
                return View(product);
            }
        }

        public IActionResult Common()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(context.Products);
        }

        public IActionResult Html()
        {
            return View((object)"This is a <h3><i>string</i></h3>");
        }
    }
}