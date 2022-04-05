using GBCSporting_Flip_Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GBCSporting_Flip_Framework.Controllers
{
    public class ProductController : Controller
        
    {
        private GBCSportingContext context;

        public ProductController(GBCSportingContext ctx)
        {
            this.context = ctx;
        }


        [Route("[controller]s")]
        public IActionResult Index()
        {
            
            List<Product> products;
            products = context.Products.OrderBy(p => p.Code).ToList();

            // bind products to view
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Product());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {

            if (ModelState.IsValid)
            {
                if (product.ProductId == 0)
                {
                    context.Products.Add(product);
                    TempData["confirmMessage"] = $"New Product Added";
                }
                else
                {
                    context.Products.Update(product);
                    TempData["confirmMessage"] = $"Prodcut Updated";
                }
                    
                context.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.Action = (product.ProductId == 0) ? "Add" : "Edit";
                ModelState.AddModelError("", "There are errors in the form.");
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete";
            var product = context.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }


    }
}
