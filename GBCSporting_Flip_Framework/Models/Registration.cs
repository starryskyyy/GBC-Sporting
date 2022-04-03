using System.ComponentModel.DataAnnotations;

namespace GBCSporting_Flip_Framework.Models
{
    public class Registration
    {
        [Range(1, 1000, ErrorMessage = "Please select a customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [Range(1, 1000, ErrorMessage = "Please select a product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public string Slug => Customer?.FullName.Replace(' ', '-').ToLower();
    }
}
