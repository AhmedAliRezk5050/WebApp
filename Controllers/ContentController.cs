using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ContentController : ControllerBase
    {
        private DataContext context;

        public ContentController(DataContext dataContext)
        {
            context = dataContext;
        }

        [HttpGet("string")]
        public string GetString() => "This is a string response";

        [HttpGet("object")]
        public async Task<Product> GetObject()
        {
            return await context.Products.FirstAsync();
        }
    }
}