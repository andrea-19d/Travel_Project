using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class GuidesPageController : Controller
    {
        // GET: GudesPage
        public ActionResult Guides()
        {
            return View();
        }
    }
}