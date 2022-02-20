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
        public IActionResult Index()
        {
            List<Technician> technicians;
            technicians = context.Technicians.OrderBy(t => t.TechnicianId).ToList();

            // bind technicians to view
            return View(technicians);
        }
    }
}
