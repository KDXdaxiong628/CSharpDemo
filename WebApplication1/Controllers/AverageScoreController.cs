using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

/*
 * 简单的计算器
 * 
 */
namespace WebApplication1.Controllers
{
    public class AverageScoreController : Controller
    {
        // GET: AverageScore
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAvgScore()
        {
    
            string a = Request.Params["sumScore"];
            int sumScore = Convert.ToInt32(Request.Params["sumScore"]);
            int sumSubject = Convert.ToInt32(Request.Params["sumSubject"]);
            MyCalculator objCal = new MyCalculator();
            int result = objCal.GetAvg(sumScore, sumSubject);

            ViewData["avgScore"] = "您的平均成绩是：" + result;
            return View("Index");
        }
    }
}