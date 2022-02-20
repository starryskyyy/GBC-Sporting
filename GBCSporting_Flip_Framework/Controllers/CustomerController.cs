using GBCSporting_Flip_Framework.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBCSporting_Flip_Framework.Controllers
{
    public class CustomerController : Controller
    {
        private GBCSportingContext context;

        public CustomerController(GBCSportingContext ctx)
        {
            this.context = ctx;
        }


        [Route("[controller]s")]
        public IActionResult Index()
        {
            List<Customer> customers;
            customers = context.Customers.OrderBy(c => c.CustomerId).ToList();

            // bind customers to view
            return View(customers);
        }
    }
}
