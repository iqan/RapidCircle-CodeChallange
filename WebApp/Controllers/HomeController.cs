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

        const string errorMessage = "Something went wrong! Close the browser and try again."+
            " If issue is still there please clear cookies/cache and try again.";

        public ActionResult Timeline()
        {
            return View();
        }

        public ActionResult Network()
        {
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
                return Json(new { error = errorMessage, errorDetails = ex.Message, innerException = ex.InnerException.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}