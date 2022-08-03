using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    public class FormController : Controller
    {
        private DataContext context;

        public FormController(DataContext dbContext)
        {
            context = dbContext;
        }

        public async Task<IActionResult> Index(long id = 1)
        {
            var product = await context.Products
                            .Include(p => p.Category)
                            .Include(p => p.Supplier)
                            .FirstOrDefaultAsync(p => p.ProductId == id);

            return View("Form", null);
        }

        [HttpPost]
        public IActionResult SubmitForm()
        {
            foreach (string key in Request.Form.Keys.Where(k => !k.StartsWith("_")))
            {
                TempData[key] = string.Join(", ", Request.Form[key]);
            }

            return RedirectToAction(nameof(Results));
        }

        public IActionResult Results()
        {
            return View();
        }
    }
}