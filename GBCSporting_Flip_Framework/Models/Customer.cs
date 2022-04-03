﻿using System.ComponentModel.DataAnnotations;
namespace GBCSporting_Flip_Framework.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Please enter a first name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage ="Please enter a last name")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Please enter a address")]

        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        public string? Address { get; set; }

        [Required(ErrorMessage ="Please enter a city")]
        public string? City   { get; set; }

        [Required(ErrorMessage ="Please enter a state")]
        public string? State { get; set; }

        [Required(ErrorMessage ="Please enter a postal code")]
        public string? PostalCode { get; set; }

        [Range (1,15, ErrorMessage = "Please select a country")]
        public int CountryId { get; set; }
        public Country? Country { get; set; }

        public string? CustEmail { get; set; }
        public string? CustPhone { get; set; }

        public ICollection<Registration> Registrations { get; set; }
        public string Slug => FirstName?.Replace(' ', '-').ToLower()
             + '-' + LastName?.Replace(' ', '-').ToLower();
    }
}
