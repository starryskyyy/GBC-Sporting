using GBCSporting_Flip_Framework.Models;

namespace GBCSporting_Flip_Framework
{
    public static class Check
    {
        public static string EmailExists(GBCSportingContext ctx, string email)
        {
            string msg = "";
            if (!string.IsNullOrEmpty(email))
            {
                Customer customer = ctx.Customers.FirstOrDefault(c => c.CustEmail.ToLower() == email.ToLower());
                if (customer != null)
                    msg = $"Email address {email} is already in use.";
            }
            return msg;
        }

        public static string EmailExistsTech(GBCSportingContext ctx, string email)
        {
            string msg = "";
            if (!string.IsNullOrEmpty(email))
            {
                Technician technician = ctx.Technicians.FirstOrDefault(t => t.TechEmail.ToLower() == email.ToLower());
                if (technician != null)
                    msg = $"Email address {email} is already in use.";
            }
            return msg;
        }

    }
}
