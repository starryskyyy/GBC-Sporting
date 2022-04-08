using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace GBCSporting_Flip_Framework.Models
{
    public class Technician
    {
        [Key]
        public int TechnicianId { get; set; }

        [Required(ErrorMessage ="Please enter a name")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Technician Name may not contain any special characters.")]
        public string? TechName { get; set; }

        [Required(ErrorMessage ="Please enter a email")]
        [DataType(DataType.EmailAddress)]
        [Remote("CheckEmailTech", "Validation")]
        public string? TechEmail { get; set; }

        [Required(ErrorMessage ="Please enter a phone")]
        [RegularExpression("^(\\+\\d{1,2}\\s)?\\(?\\d{3}\\)?[\\s.-]\\d{3}[\\s.-]\\d{4}$",
            ErrorMessage = "Phone number format must be ### ###-####")]
        public string? TechPhone { get; set; }

        public string? Slug => TechName?.Replace(' ', '-').ToLower();
    }
}
