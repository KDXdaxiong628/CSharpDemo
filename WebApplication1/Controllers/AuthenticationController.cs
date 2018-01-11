using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        //当点击登录时，Dologin action 方法会被调用。
        /*
            Dologin 方法的功能：
            通过调用业务层功能检测用户是否合法。
            如果是合法用户，创建认证Cookie。可用于以后的认证请求过程中。
            如果是非法用户，给当前的ModelState添加新的错误信息，将错误信息显示在View中。
         */
        [HttpPost]
        public ActionResult DoLogin(UserDetails u)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
                if (bal.IsValidUser(u))
                {
                    //false决定了是否创建永久有用的Cookie。临时Cookie会在浏览器关闭时自动删除，永久Cookie不会被删除。可通过浏览器设置或是编写代码手动删除。
                    FormsAuthentication.SetAuthCookie(u.UserName, false);
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}