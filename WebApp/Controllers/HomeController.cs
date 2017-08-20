using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.BusinessLogic;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        string _accessToken;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Timeline()
        {
            try
            {
                if (string.IsNullOrEmpty(_accessToken))
                {
                    var accessToken = Users.GetAccessToken(this.HttpContext);
                    _accessToken = accessToken.Result;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred. Detais: " + ex.Message;
            }
            return View();
        }
    }
}