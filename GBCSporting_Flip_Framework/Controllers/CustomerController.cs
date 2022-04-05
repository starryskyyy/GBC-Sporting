﻿using GBCSporting_Flip_Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting_Flip_Framework.Controllers
{
    public class CustomerController : Controller
    {
        private GBCSportingContext context;

        public CustomerController(GBCSportingContext ctx)
        {
            this.context = ctx;
        }


        [Route("[controller]s")]
        public IActionResult Index()
        {
            List<Customer> customers;
            customers = context.Customers.OrderBy(c => c.CustomerId).ToList();

            // bind customers to view
            return View(customers);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Countries = context.Countries.OrderBy(c => c.CountryName).ToList();
            return View("Edit", new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = context.Countries.OrderBy(c => c.CountryName).ToList();
            var customer = context.Customers.Find(id);

            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (TempData["okEmail"] == null)
            {
                string message = Check.EmailExists(context, customer.CustEmail);
                if (!String.IsNullOrEmpty(message))
                {
                    ModelState.AddModelError(nameof(Customer.CustEmail), message);
                }
            }

            if (ModelState.IsValid)
            {
                if (customer.CustomerId == 0)
                    context.Customers.Add(customer);
                else
                    context.Customers.Update(customer);
                context.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ViewBag.Action = (customer.CustomerId == 0) ? "Add" : "Edit";
                ViewBag.Countries = context.Countries.OrderBy(c => c.CountryName).ToList();
                return View(customer);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers
                .Include(c => c.Country)
                .FirstOrDefault(c => c.CustomerId == id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

    }
}
