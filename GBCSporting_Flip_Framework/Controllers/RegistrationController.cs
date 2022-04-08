using GBCSporting_Flip_Framework.Models;
using GBCSporting_Flip_Framework.Models.DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting_Flip_Framework.Controllers
{
    public class RegistrationController : Controller

    {
        private GBCSportingContext context;

        public RegistrationController(GBCSportingContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        [Route("[controller]s")]
        public ViewResult Index()
        {
            List<Customer> customers = context.Customers.OrderBy(c => c.CustomerId).ToList();
            return View(customers);
        }

        [HttpPost]
        public IActionResult Register(int customerId)
        {
            HttpContext.Session.SetInt32("customerId", customerId);
            IEnumerable<Registration> registrations = context.Registrations.Where(c => c.CustomerId == customerId).OrderBy(c => c.ProductId);
            ViewBag.Products = context.Products.OrderBy(c => c.ProductId).ToList();
            return View(registrations);
        }

        [HttpPost]
        public IActionResult Add(int productId)
        {
            if (productId == 0)
            {
                TempData["ErrorMessage"] = "Please choose a product";
                return RedirectToAction("Register");
            }
            int customerId = (int)HttpContext.Session.GetInt32("customerId");
            bool registrationAlreadyExist = context.Registrations.Where(r => r.CustomerId == customerId && r.ProductId == productId).AsNoTracking().FirstOrDefault() != null;
            if (registrationAlreadyExist)
            {
                TempData["ErrorMessage"] = "This registration is already existed";
                return RedirectToAction("Register");
            }
            context.Registrations.Add(new Registration { CustomerId = customerId, ProductId = productId });
            context.SaveChanges();
            TempData["SuccessMessage"] = "Product added to registration";
            return RedirectToAction("Register");
        }
        public IActionResult Register3(int customerId)
        {
            return View();
        }
        public IActionResult Register4(int customerId)
        {
            return View();
        }
        public IActionResult Register5(int customerId)
        {
            return View();
        }
        public IActionResult Register6(int customerId)
        {
            return View();
        }
    }
}
