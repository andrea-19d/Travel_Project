using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class LogInPageController : Controller
    {
        // GET: LogInPage
        public ActionResult LogIn()
        {
            return View();
        }
    }
}