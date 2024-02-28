using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class ContactPageController : Controller
    {
        // GET: ContactPage
        public ActionResult Contact()
        {
            return View();
        }
    }
}