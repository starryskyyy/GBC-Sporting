namespace GBCSporting_Flip_Framework.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Product> AllProducts { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public string SearchTerm { get; set; }
        public string Header { get; set; }
    }
}
