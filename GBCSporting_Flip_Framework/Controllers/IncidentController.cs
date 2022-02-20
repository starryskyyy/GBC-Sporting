using Microsoft.AspNetCore.Mvc;
using GBCSporting_Flip_Framework.Models;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting_Flip_Framework.Controllers
{
    public class IncidentController : Controller
    {
        private GBCSportingContext context;

        public IncidentController(GBCSportingContext ctx)
        {
            this.context = ctx;
        }


        [Route("[controller]s")]
        public IActionResult Index()
        {
            List<Incident> incidents;
            incidents = context.Incidents.Include(c => c.Customer).Include(p => p.Product).OrderBy(i => i.IncidentId).ToList();

            // bind incidents to view
            return View(incidents);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(t => t.TechName).ToList();
            ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();
            return View("Edit", new Incident());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(t => t.TechName).ToList();
            ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();
            var incident = context.Incidents.Find(id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                if (incident.IncidentId == 0)
                    context.Incidents.Add(incident);
                else
                    context.Incidents.Update(incident);
                context.SaveChanges();
                return RedirectToAction("Index", "Incident");
            }
            else
            {
                ViewBag.Action = (incident.IncidentId == 0) ? "Add" : "Edit";
                return View(incident);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Incidents.Find(id);
            return View(incident);
        }
        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("Index", "Incident");
        }
    }
}
