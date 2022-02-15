using System.ComponentModel.DataAnnotations;

namespace GBCSporting_Flip_Framework.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please enter a code")]
        public string? Code { get; set; }
        [Required(ErrorMessage = "Please enter a name of the product")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter a yearly price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? YearlyPrice  { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public String Slug => Code?.Replace(' ', '-').ToLower()
             + '-' + Name?.Replace(' ', '-').ToLower();


    }
}
