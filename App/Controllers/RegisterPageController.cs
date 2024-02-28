using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class RegisterPageController : Controller
    {
        // GET: RegisterPage
        public ActionResult Register()
        {
            return View();
        }
    }
}