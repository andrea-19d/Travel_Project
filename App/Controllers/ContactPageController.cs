using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class ContactPageController : BaseController
    {
        // GET: ContactPage
        public ActionResult Contact()
        {
            string role = SessionStatus();
            return View();
        }
    }
}