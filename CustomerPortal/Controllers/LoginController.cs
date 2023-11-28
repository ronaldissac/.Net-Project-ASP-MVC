using CustomerPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.WebControls;

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
                Session["TimeOut"] = HttpContext.Session.Timeout;
                Session["customerID"] = customer.CustomerId;
                Session["customerName"] = customer.CustomerName;
                FormsAuthentication.SetAuthCookie(customer.CustomerId, true);
                return RedirectToAction("index", "Home");

            }
            else
            {
                TempData["Errormsg"]= "Invalid Login ID / Password !";
                return RedirectToAction("CustomerLogin", "Login");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        
        public ActionResult Register(Customer customer)
        {
           string Result = customer.CustomerRegister();
            if (Result == "success")
            {
                TempData["Errormsg"] = "Registered successfully please Login";
                return RedirectToAction("CustomerLogin", "Login");
            }
            else
            {
                TempData["Errormsg"] = Result;
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("CustomerLogin", "Login");
        }
    }

}