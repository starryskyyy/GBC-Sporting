
using System.ComponentModel.DataAnnotations;

namespace GBCSporting_Flip_Framework.Models
{
    public class IdCheck : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int)
            {
                int idToCheck = (int)value;
                if(idToCheck > 0)
                {
                    return ValidationResult.Success;
                }
            }

            string msg = base.ErrorMessage ??
                $"Please pick a customer";
            return new ValidationResult(msg);
        }
    }
}
