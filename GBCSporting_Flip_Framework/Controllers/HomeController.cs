using GBCSporting_Flip_Framework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GBCSporting_Flip_Framework.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}