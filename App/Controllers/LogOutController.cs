using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace App.Controllers
{
    public class LogOutController : Controller
    {
        // GET: LogOut
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn", "LogInPage");
            /* return View();*/
        }
    }
}