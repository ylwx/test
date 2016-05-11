using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication3.Bll;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpPost]
        public ActionResult DoLogin(UserDetails u)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer bal = new EmployeeBusinessLayer();

                if (bal.IsValidUser(u))
                {
                    FormsAuthentication.SetAuthCookie(u.UserName, false);  //存储username

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

        //
        // GET: /Authentication/
        public ActionResult Index()
        {
            return View();
        }

        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }
    }
}