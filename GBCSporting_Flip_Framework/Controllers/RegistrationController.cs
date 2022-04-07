using GBCSporting_Flip_Framework.Models;
using GBCSporting_Flip_Framework.Models.DataLayer;
using GBCSporting_Flip_Framework.Models.DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting_Flip_Framework.Controllers
{
    public class RegistrationController : Controller

    {
        private GBCSportingContext context { get; set; }
        
        private GBCSportingUnitOfWork data { get; set; }
        public RegistrationController(GBCSportingContext ctx) => data = new GBCSportingUnitOfWork(ctx);
     

        [Route("[controller]s")]
        public IActionResult Index()
        {
            var customer = data.Customers.List(new QueryOptions<Customer>
            {
                OrderBy = a => a.FirstName
            });
            return View(customer);
        }

        [HttpPost]
        public RedirectToActionResult ViewProducts(int id)
        {
            var customer = data.Customers.Get(id);
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
            return RedirectToAction("Search");
        }

        [HttpGet]
        public ViewResult Search()
        {
            //ViewBag.Products = context.Products.OrderBy(c => c.Name).ToList();
            var search = new SearchData(TempData);
            if (search.HasSearchTerm)
            {
                var vm = new ProductsViewModel
                {
                    SearchTerm = search.SearchTerm
                };

                var options = new QueryOptions<Product>
                {};
               
                int index = vm.SearchTerm.LastIndexOf(' ');
                if (index == -1)
                {
                    options.Where = b => b.Registrations.Any(
                        ba => ba.Customer.FirstName.Contains(vm.SearchTerm) || 
                        ba.Customer.LastName.Contains(vm.SearchTerm));
                }
                else
                {
                    string first = vm.SearchTerm.Substring(0, index);
                    string last = vm.SearchTerm.Substring(index + 1);
                    options.Where = b => b.Registrations.Any(
                        ba => ba.Customer.FirstName.Contains(first) &&
                        ba.Customer.LastName.Contains(last));
                }
                vm.Header = $"Customer: {vm.SearchTerm}";
                vm.AllProducts = data.Products.List();
                vm.Products = data.Products.List(options);
                return View("Register", vm);
            }
            else
            {
                return View("Index");
            }
        }
        
    }
}
