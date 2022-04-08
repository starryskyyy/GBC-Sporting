using GBCSporting_Flip_Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting_Flip_Framework.Controllers
{
    public class TechIncidentController : Controller
    {
        private GBCSportingContext context;

        public TechIncidentController(GBCSportingContext ctx)
        {
            this.context = ctx;
        }

        public IActionResult Get()
        {
            ViewBag.Technicians = context.Technicians.OrderBy(t => t.TechnicianId).ToList();
            return View();
        }

        [HttpGet]
        public IActionResult List(Technician? technician, int? id)
        {
            if (technician.TechnicianId == 0 && id == null)
            {
                ViewBag.Technicians = context.Technicians.ToList();
                ViewBag.Customers = context.Customers.ToList();
                ViewBag.Products = context.Products.ToList();
                ViewBag.error = "Please select a technician !";
                return View("Get");
            }

            int Id = technician.TechnicianId;

            if (Id == 0 && (int)id !=0)
            {
                Id = (int)id;
            }

            // save TechiniciansId to the session
            HttpContext.Session.SetInt32("TechId", Id);
            ViewBag.Technicians = context.Technicians.ToList();
            ViewBag.Customers = context.Customers.ToList();
            ViewBag.Products = context.Products.ToList();

            if (Id != 0)
            { 
                var TechIncidents = context.Incidents.Where(g => g.TechnicianId == Id).ToList();

                ViewBag.name = context.Technicians.Find(Id).TechName;

                if (TechIncidents.Count == 0)
                {
                    ViewBag.Error = "There is no incidents available for " + ViewBag.Name;
                }
                return View("List", TechIncidents);
            }

            ViewBag.error = "Please select a technician !";
            return View("Get");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Technicians = context.Technicians.ToList();
            ViewBag.Customers = context.Customers.ToList();
            ViewBag.Products = context.Products.ToList();
            ViewBag.Incidents = context.Incidents.ToList();
            var i = context.Incidents.Find(id);
            return View(i);
        }

        [HttpPost]
        public IActionResult Edit(Incident i)
        {
            int id = (int)HttpContext.Session.GetInt32("TechId");

            if (ModelState.IsValid)
            {
                context.Incidents.Update(i);
                context.SaveChanges();
                TempData["confirmMessage"] = $"Incident \"{i.Title}\" updated";
                return RedirectToAction("List", new {id=id});

            }
            return View(i);

        }

    }

        


    

}
