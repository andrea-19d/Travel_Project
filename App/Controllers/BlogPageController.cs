using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class BlogPageController : Controller
    {
        // GET: BlogPage
        public ActionResult Blog()
        {
            return View();
        }
    }
}