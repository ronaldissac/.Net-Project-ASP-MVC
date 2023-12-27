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
    [SessionExpire]
    public class HomeController : Controller
    {
        Home home = new Home();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details()
        {
            //Home home = new Home();
            try
            {
                if (Session["customerID"].ToString() != null)
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

        [HttpGet]
        public ActionResult Export()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Export(string id)
        {
            if(!string.IsNullOrEmpty(id)) 
            {
            }
            return View(id);
        }
        public ActionResult Import()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult SaveMail(int id, int Type, string Data)
        {
            try
            {
                if (home.Update(id, Type, Data))
                {
                    return Json(new { success = true });
                }
                else
                    return Json(new { success = false });
            }
            catch(Exception ex)
            {
                return JavaScript(ex.Message);
            } 
        }
        public ActionResult SavePhone(int id,int Type, string Data)
        {
            try
            {
                if (home.Update(id, Type, Data))
                {
                    return Json(new { success = true });
                }
                else
                    return Json(new { success = false });
            }
            catch(Exception ex)
            {
                return JavaScript(ex.Message);
            }
        }
    }
}