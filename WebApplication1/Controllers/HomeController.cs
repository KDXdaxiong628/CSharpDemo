using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        public string JsonReturn()
        {
            ViewBag.Message = "Your contact page.";

            var result = new object[] { new { name = "linfei", age = "22", address = "wuhan" }, new { name = "linfei", arg = "26", address = "sh" } };

            //MVC中返回
            //return Json(result);

            //asp.net中返回
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            return js.Serialize(result);

        }
    }
}