using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class ServicePageController : Controller
    {
        // GET: ServicePage
        public ActionResult Services()
        {
            return View();
        }
    }
}