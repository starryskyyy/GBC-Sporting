using System.ComponentModel.DataAnnotations;

namespace GBCSporting_Flip_Framework.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        
        [Required(ErrorMessage = "Please enter a code")]
        [RegularExpression("^[a-zA-Z0-9-]+$", ErrorMessage = "Name may not contain any special characters.")]
        public string? Code { get; set; }

        [Required(ErrorMessage = "Please enter a name of the product")]
        [RegularExpression("^[a-zA-Z0-9 -.]+$", ErrorMessage = "Name may not contain any special characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter a yearly price")]
        [Range(0, 1000000, ErrorMessage = "Price must be between 0 - 1000000")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double? YearlyPrice  { get; set; }

        [Required(ErrorMessage = "Please enter a date")]
        [Range(typeof(DateTime),"1/1/1900", "12/31/9999", ErrorMessage = "Release date must be after 1/1/1900.")]
        public DateTime? ReleaseDate { get; set; } = DateTime.Now;

        public ICollection<Registration>? Registrations { get; set; }
        public string Slug => Code?.Replace(' ', '-').ToLower()
             + '-' + Name?.Replace(' ', '-').ToLower();


    }
}
