﻿using Microsoft.AspNetCore.Mvc;

namespace GBCSporting_Flip_Framework.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
