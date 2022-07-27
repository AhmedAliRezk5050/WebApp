using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private DataContext context;

        public ProductsController(DataContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IAsyncEnumerable<Product> GetProducts()
        {
            return context.Products.AsAsyncEnumerable();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(long id)
        {
            Product? product = await context.Products.FindAsync(id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody] ProductBindingTarget target)
        {
            Product product = target.ToProduct();

            await context.Products.AddAsync(product);

            await context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpPut]
        public async Task UpdateProduct([FromBody] Product product)
        {
            context.Products.Update(product);

            await context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct(long id)
        {
            context.Products.Remove(new Product() { ProductId = id });

            await context.SaveChangesAsync();
        }
    }
}