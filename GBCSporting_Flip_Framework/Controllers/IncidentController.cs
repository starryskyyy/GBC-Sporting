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

    }
}
