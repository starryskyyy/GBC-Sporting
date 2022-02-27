﻿using System.ComponentModel.DataAnnotations;
namespace GBCSporting_Flip_Framework.Models
{
    public class Incident
    {
        [Key]
        public int IncidentId { get; set; }
        
        [Range(1,1000, ErrorMessage ="Please select a customer")] 
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
       
        [Range(1, 1000, ErrorMessage = "Please select a product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required(ErrorMessage ="Please enter a title")]
        public string? Title { get; set; }

        [Required(ErrorMessage ="Please enter a description")]
        public string? Description { get; set; }

        public int? TechnicianId { get; set; }
        public Technician? Technician { get; set; }

        public DateTime? DateOpened     { get; set; }

        public DateTime? DateClosed { get; set; }

        public string? Slug => Title?.Replace(' ', '-').ToLower();

    }
}
