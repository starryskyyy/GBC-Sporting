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
        public ViewResult Index(string activeStatus = "all")
        {

            IQueryable<Incident> incidents = context.Incidents.Include(c => c.Customer).Include(p => p.Product).OrderBy(i => i.IncidentId);
           
            if (activeStatus.Equals("unassigned"))
            {
                incidents = incidents.Where(i => i.TechnicianId == null);
            } else if (activeStatus.Equals("open"))
            {
                incidents = incidents.Where(i => i.DateClosed == null);
            }

            var model = new IncidentListViewModel
            {
                Incidents = incidents.ToList(),
                SelectedStatus = activeStatus,
            };

            return View(model);
        }

        [HttpGet]
        public ViewResult Add()
        {
            var model = new IncidentEditViewModel
            {
                operation = "Add",
                Incident = new Incident(),
                Customers = context.Customers.OrderBy(c => c.FirstName).ToList(),
                Technicians = context.Technicians.OrderBy(t => t.TechName).ToList(),
                Products = context.Products.OrderBy(p => p.Name).ToList()
            };
            return View("Edit", model);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var i = context.Incidents.Find(id);

            var model = new IncidentEditViewModel
            {
                operation = "Edit",
                Incident = i,
                Customers = context.Customers.OrderBy(c => c.FirstName).ToList(),
                Technicians = context.Technicians.OrderBy(t => t.TechName).ToList(),
                Products = context.Products.OrderBy(p => p.Name).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                if (incident.DateOpened is null)
                {
                    incident.DateOpened = DateTime.Now;
                }
                if (incident.IncidentId == 0)
                {
                    context.Incidents.Add(incident);
                    TempData["confirmMessage"] = $"New Incident \"{incident.Title}\" Added";
                }
                else
                {
                    context.Incidents.Update(incident);
                    TempData["confirmMessage"] = $"Incident \"{incident.Title}\" Edited";
                }

                context.SaveChanges();
                return RedirectToAction("Index", "Incident");
            }
            else
            {
                var model = new IncidentEditViewModel
                {
                    operation = (incident.IncidentId == 0) ? "Add" : "Edit",
                    Incident = incident,
                    Customers = context.Customers.OrderBy(c => c.FirstName).ToList(),
                    Technicians = context.Technicians.OrderBy(t => t.TechName).ToList(),
                    Products = context.Products.OrderBy(p => p.Name).ToList()
                };
                return View(model);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var incident = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Technician)
                .Include(i => i.Product)
                .FirstOrDefault(i => i.IncidentId == id);
            return View(incident);
        }
        [HttpPost]
        public RedirectToActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            TempData["confirmMessage"] = $"Incident \"{incident.Title}\" Deleted";

            context.SaveChanges();
            return RedirectToAction("Index", "Incident");
        }
    }
}
