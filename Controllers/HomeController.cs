using Microsoft.AspNetCore.Mvc;
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
            Product? product = await context.Products.FindAsync(id);

            if(product?.CategoryId == 1)
            {
                return View("Watersports", product);
            } else
            {
                return View(product);
            }
        }
    }
}