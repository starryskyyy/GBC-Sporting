using GBCSporting_Flip_Framework.Models;
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
        public ViewResult Get()
        {
            List<Customer> customers = context.Customers.OrderBy(c => c.CustomerId).ToList();
            return View(customers);
        }

        private List<Product> getUnregisteredProducts(List<Registration> registrations, List<Product> products)
        {
            foreach (Registration registration in registrations)
            {
                foreach(Product product in products.ToList())
                {
                    if (registration.ProductId == product.ProductId)
                    {
                        products.Remove(product);
                        break;
                    }
                }   
            }
            return products;
        }

        public IActionResult Register(int customerId)
        {
            if (customerId == 0)
            {
                TempData["ErrorMessage"] = "Please choose a customer!";
                return RedirectToAction("Get");
            }
            HttpContext.Session.SetInt32("customerId", customerId);
            List<Registration> registrations = context.Registrations.Where(c => c.CustomerId == customerId).Include(c => c.Product).OrderBy(c => c.ProductId).ToList();
            List<Product> products = context.Products.OrderBy(c => c.ProductId).ToList();

            Customer c = context.Customers.Find(customerId);
            ViewBag.Customer = c;

            if (registrations.Count == 0)
            {
                TempData["NoProductMessage"] = $"There are no products registered for {c.FullName}";
            }
            ViewBag.Products = getUnregisteredProducts(registrations, products); 
            return View(registrations);
        }

        [HttpPost]
        public IActionResult Add(int productId)
        {
            int customerId = (int)HttpContext.Session.GetInt32("customerId");
            if (productId == 0)
            {
                TempData["ErrorMessage"] = "Please choose a product";
                return RedirectToAction("Register", new { customerId });
            }
            bool registrationAlreadyExist = context.Registrations.Where(r => r.CustomerId == customerId && r.ProductId == productId).AsNoTracking().FirstOrDefault() != null;
            if (registrationAlreadyExist)
            {
                TempData["ErrorMessage"] = "This registration is already existed";
                return RedirectToAction("Register", new { customerId });
            }
            context.Registrations.Add(new Registration { CustomerId = customerId, ProductId = productId });
            context.SaveChanges();
            TempData["SuccessMessage"] = "Product added to registration";
            return RedirectToAction("Register", new { customerId });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            int customerId = (int)HttpContext.Session.GetInt32("customerId");
            Registration reg = context.Registrations.Find(id);
            context.Registrations.Remove(reg);
            TempData["SuccessMessage"] = "Registration deleted";
            context.SaveChanges();
            TempData["SuccessMessage"] = $"Product removed from registration";
            return RedirectToAction("Register", new { customerId });
        }
    }
}
