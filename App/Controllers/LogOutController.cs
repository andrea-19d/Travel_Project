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

        /* nu lucreasa inca, mai incercam */
        public ActionResult LogOut()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            if (Response.Cookies["X-KEY"] != null)
            {
                var cookie = new HttpCookie("X-KEY")
                {
                    Expires = DateTime.Now.AddDays(-1),
                    HttpOnly = true
                };
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("LogIn", "Login");
        }
    }
}