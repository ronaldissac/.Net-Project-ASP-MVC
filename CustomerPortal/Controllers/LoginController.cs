using CustomerPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CustomerPortal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult CustomerLogin()
        {

            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult CustomerLogin(Customer customer)
        {
            if(customer.Validation() == true)
            {
                return RedirectToAction("index", "Home");
                
            }
            else
            {
                TempData["Errormsg"]= "Invalid Login ID / Password !";
                return RedirectToAction("CustomerLogin", "Login");
            }
        }
    }
}