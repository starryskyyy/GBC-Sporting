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
        [Range(0, 1000000, ErrorMessage = "Price must be between 0 - 1000000")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double? YearlyPrice  { get; set; }

        [Required(ErrorMessage = "Please enter a date")]
        public DateTime? ReleaseDate { get; set; } = DateTime.Now;

        public ICollection<Registration> Registrations { get; set; }
        public string Slug => Code?.Replace(' ', '-').ToLower()
             + '-' + Name?.Replace(' ', '-').ToLower();


    }
}
