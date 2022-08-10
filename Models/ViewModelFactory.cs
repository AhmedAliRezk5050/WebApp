namespace WebApp.Models
{
    public static class ViewModelFactory
    {
        public static ProductViewModel Details(Product p)
        {
            return new ProductViewModel
            {
                Product = p,
                Action = "Details",
                ReadOnly = true,
                Theme = "info",
                ShowAction = false,
                Categories = p == null || p.Category == null
                                  ? Enumerable.Empty<Category>()
                                  : new List<Category> { p.Category },
                Suppliers = p == null || p.Supplier == null
                                  ? Enumerable.Empty<Supplier>()
                                  : new List<Supplier> { p.Supplier },
            };
        }
    }
}