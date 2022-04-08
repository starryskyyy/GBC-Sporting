using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace GBCSporting_Flip_Framework.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please enter a first name")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "First name may not contain any special characters.")]
        [StringLength(51)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Last name may not contain any special characters.")]
        [StringLength(51)]
        public string? LastName { get; set; }

        public string FullName { get { return this.FirstName + " " + this.LastName; } }

        [Required(ErrorMessage ="Please enter a address")]
        [StringLength(51)]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Please enter a city")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "City may not contain any special characters.")]
        [StringLength(51)]
        public string? City   { get; set; }

        [Required(ErrorMessage = "Please enter a state")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "State may not contain any special characters.")]
        [StringLength(51)]
        public string? State { get; set; }

        [Required(ErrorMessage ="Please enter a postal code")]
        [StringLength(21)]
        public string? PostalCode { get; set; }

        [Range(1, 15, ErrorMessage = "Please select a country")]
        public int CountryId { get; set; }

        public Country? Country { get; set; }

        [DataType(DataType.EmailAddress)]
        [Remote("CheckEmail", "Validation")]
        public string? CustEmail { get; set; }

        [RegularExpression("^(\\+\\d{1,2}\\s)?\\(?\\d{3}\\)?[\\s.-]\\d{3}[\\s.-]\\d{4}$", 
            ErrorMessage = "Phone number format must be ### ###-####")]
        public string? CustPhone { get; set; }

        public ICollection<Registration>? Registrations { get; set; }
        public string Slug => FirstName?.Replace(' ', '-').ToLower()
             + '-' + LastName?.Replace(' ', '-').ToLower();

    }
}
