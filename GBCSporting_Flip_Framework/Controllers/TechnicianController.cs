using GBCSporting_Flip_Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting_Flip_Framework.Controllers
{
    public class TechnicianController : Controller
    {
        private GBCSportingContext context;

        public TechnicianController(GBCSportingContext ctx)
        {
            this.context = ctx;
        }


        [Route("[controller]s")]
        public ViewResult Index()
        {
            List<Technician> technicians;
            technicians = context.Technicians.OrderBy(t => t.TechnicianId).ToList();

            // bind technicians to view
            return View(technicians);
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Technician());
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var technician = context.Technicians.Find(id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            if (TempData["okEmail"] == null)
            {
                string message = Check.EmailExistsTech(context, technician.TechEmail);
                if (!String.IsNullOrEmpty(message))
                {
                    ModelState.AddModelError(nameof(Technician.TechEmail), message);
                }
            }

            if (ModelState.IsValid)
            {
                if (technician.TechnicianId == 0)
                    context.Technicians.Add(technician);
                else
                    context.Technicians.Update(technician);
                context.SaveChanges();
                return RedirectToAction("Index", "Technician");
            }
            else
            {
                ViewBag.Action = (technician.TechnicianId == 0) ? "Add" : "Edit";
                return View(technician);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var technician = context.Technicians.Find(id);
            return View(technician);
        }
        [HttpPost]
        public RedirectToActionResult Delete(Technician technician)
        {
            context.Technicians.Remove(technician);
            context.SaveChanges();
            return RedirectToAction("Index", "Technician");
        }
    }
}
