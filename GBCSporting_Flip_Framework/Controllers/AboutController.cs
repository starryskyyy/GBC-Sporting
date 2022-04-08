using Microsoft.AspNetCore.Mvc;

namespace GBCSporting_Flip_Framework.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
