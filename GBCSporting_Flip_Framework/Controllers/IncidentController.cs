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
        public IActionResult Index(string activeStatus = "all")
        {
            List<Incident> incidents;

           
            if (activeStatus == "unassigned")
            {
                incidents = context.Incidents.Where(i => i.Technician == null).Include(c => c.Customer).Include(p => p.Product).OrderBy(i => i.IncidentId).ToList();
            } else if (activeStatus == "open")
            {
                incidents = context.Incidents.Where(i => i.DateClosed == null).Include(c => c.Customer).Include(p => p.Product).OrderBy(i => i.IncidentId).ToList();
            }
            else
            {
                incidents = context.Incidents.Include(c => c.Customer).Include(p => p.Product).OrderBy(i => i.IncidentId).ToList();
            }

            var model = new IncidentListViewModel
            {
                Incidents = incidents,
                SelectedStatus = activeStatus,
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
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
        public IActionResult Edit(int id)
        {
            List<Incident> incidents;
            incidents = context.Incidents.Include(c => c.Customer).Include(p => p.Product).OrderBy(i => i.IncidentId).ToList();
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
                    TempData["confirmMessage"] = $"New Incident Added";
                }

                else
                {
                    context.Incidents.Update(incident);
                    TempData["confirmMessage"] = $"Incident Edited";
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
        public IActionResult Delete(int id)
        {
            var incident = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Technician)
                .Include(i => i.Product)
                .FirstOrDefault(i => i.IncidentId == id);
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
