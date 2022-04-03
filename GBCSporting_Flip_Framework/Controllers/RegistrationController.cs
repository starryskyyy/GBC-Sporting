using GBCSporting_Flip_Framework.Models;
using GBCSporting_Flip_Framework.Models.DataLayer;
using GBCSporting_Flip_Framework.Models.DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting_Flip_Framework.Controllers
{
    public class RegistrationController : Controller

    {
        private Repository<Customer> data { get; set; }
        public RegistrationController(GBCSportingContext ctx) => data = new Repository<Customer>(ctx);

        [Route("[controller]s")]
        public ViewResult Index()
        {
            var authors = data.List(new QueryOptions<Customer>
            {
                OrderBy = a => a.FirstName
            });
            return View(authors);
        }

        /*public IActionResult Registered(int id)
        {
            var customer = data.Get(id);
            return GoToAuthorSearch(customer);
        }

        // private helper method
        private RedirectToActionResult GoToAuthorSearch(Customer customer)
        {
            // store author search data in TempData and redirect
            var search = new SearchData(TempData)
            {
                SearchTerm = customer.FullName,
                Type = "customer"
            };
            return RedirectToAction("Search", "Product");
        }
        */


    }
}
