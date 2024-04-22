using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class AboutPageController : BaseController
    {
        // GET: About
        public ActionResult About()
        {
            string role = SessionStatus();
            return View();
        }
    }
}