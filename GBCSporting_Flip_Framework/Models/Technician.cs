using System.ComponentModel.DataAnnotations;
namespace GBCSporting_Flip_Framework.Models
{
    public class Technician
    {
        [Key]
        public int TechnicianId { get; set; }
        [Required(ErrorMessage ="Please enter a name")]
        public string? TechName { get; set; }
        [Required(ErrorMessage ="Please enter a email")]
        public string? TechEmail { get; set; }
        [Required(ErrorMessage ="Please enter a phone")]
        public string? TechPhone { get; set; }
        public String Slug => TechName?.Replace(' ', '-').ToLower();
    }
}
