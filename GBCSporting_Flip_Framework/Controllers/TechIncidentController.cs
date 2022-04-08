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

        public IActionResult Index()
        {

            ViewBag.Technicians = context.Technicians.OrderBy(t => t.TechnicianId).ToList();
            return View();
        }

        // bind data to viewbag
        public void listTable()
        {
            ViewBag.Technicians = context.Technicians.ToList();
            ViewBag.Customers = context.Customers.ToList();
            ViewBag.Products = context.Products.ToList();
            ViewBag.Incidents = context.Incidents.ToList();
        }

        [HttpGet]
        public IActionResult List(Technician? technician, int? id)
        {
            if (technician.TechnicianId == 0 && id == null)
            {
                listTable();
                ViewBag.error = "Please select a technician !";
                return View("Index");
            }

            int Id = technician.TechnicianId;

            if (Id == 0)
            {
                Id = (int)id;
            }

                // save TechiniciansId to the session
                HttpContext.Session.SetInt32("TechId", Id);
                listTable();
                var TechIncidents = context.Incidents.Where(g => g.TechnicianId == Id).ToList();
                ViewBag.name = context.Technicians.Find(Id).TechName;
                if (TechIncidents.Count == 0)
                {
                    ViewBag.Error = "There is no incidents available for " + ViewBag.Name;
                }
                return View("List", TechIncidents);

        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            listTable();
            ViewBag.Action = "Edit";
            var incident = context.Incidents.Find(id);
            return View(incident);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Incident incident)
        {

            if (ModelState.IsValid)
            {
                context.Incidents.Update(incident);
                context.SaveChanges();
                return RedirectToAction("List", incident);
            }

            int? id = HttpContext.Session.GetInt32("TechId");
            return View("Edit", incident);
        }

    }

        


    

}
