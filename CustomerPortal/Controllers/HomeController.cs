using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CustomerPortal.Models;

namespace CustomerPortal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details()
        {
            Home home = new Home();
            try
            {
                if (Session["customerID"] != null)
                {
                    List<Customer> Details = home.GetDetails(Session["customerID"].ToString());
                    return Json(Details, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string alert = "Please Relogin";
                    FormsAuthentication.SignOut();
                    return JavaScript(alert);

                }

            }
            catch (Exception ex)
            {

                return JavaScript(ex.Message);
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

     
        public JsonResult SaveMail(string mail)
        {
            try
            {
                if (mail != null)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }

            }
            catch
            {
                // Handle any errors and return a JSON response indicating failure
                return Json(new { success = false });
            }
        }
    }
}