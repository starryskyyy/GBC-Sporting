using System.ComponentModel.DataAnnotations;
namespace GBCSporting_Flip_Framework.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
