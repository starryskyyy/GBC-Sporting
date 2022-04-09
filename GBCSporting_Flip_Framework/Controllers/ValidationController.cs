using GBCSporting_Flip_Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting_Flip_Framework.Controllers
{
    public class ValidationController : Controller
    {
        private GBCSportingContext context;
        public ValidationController(GBCSportingContext ctx) => this.context = ctx;

        [Route("[controller]s")]

        public JsonResult CheckEmail(string email)
        {
            string message = Check.EmailExists(context, email);
            if (string.IsNullOrEmpty(message))
            {
                TempData["okEmail"] = true;
                return Json(true);
            }
            else return Json(message);
        }

        public JsonResult CheckEmailTech(string email)
        {
            string message = Check.EmailExistsTech(context, email);
            if (string.IsNullOrEmpty(message))
            {
                TempData["okEmail"] = true;
                return Json(true);
            }
            else return Json(message);
        }

        public JsonResult CheckCustomer(int id)
        {
            string message = Check.ValidCustomerOrProduct(context, id);
            if (string.IsNullOrEmpty(message))
            {
                TempData["okId"] = true;
                return Json(true);
            }
            else return Json(message);
        }
    }
}
