using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class PackagesPageController : Controller
    {
        // GET: PackagesPage
        public ActionResult Packages()
        {
            return View();
        }
    }
}