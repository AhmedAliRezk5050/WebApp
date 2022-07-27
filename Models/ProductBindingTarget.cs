namespace WebApp.Models
{
    public class ProductBindingTarget
    {
        public string Name { get; set; } = "";

        public decimal Price { get; set; }

        public long CategoryId { get; set; }

        public long SupplierId { get; set; }

        public Product ToProduct() => new Product()
        {
            Name = this.Name,
            Price = this.Price,
            CategoryId = this.CategoryId,
            SupplierId = this.SupplierId
        };
    }
}