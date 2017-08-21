using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.BusinessLogic;

namespace WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Timeline()
        {
            try
            {
                if (true)
                {
                    var accessToken = Users.GetAccessToken(this.HttpContext);
                    ViewBag.AccessToken = accessToken.Result;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred. Detais: " + ex.Message;
            }
            return View();
        }

        public JsonResult GetAccessToken()
        {
            try
            {
                var accessToken = Users.GetAccessToken(this.HttpContext);
                return Json(accessToken.Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred. Detais: " + ex.Message;
            }
            return null;
        }
    }
}