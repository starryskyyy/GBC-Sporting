using Microsoft.AspNetCore.Mvc;
using GBCSporting_Flip_Framework.Models;

namespace GBCSporting_Flip_Framework.Controllers
{
    public class IncidentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
