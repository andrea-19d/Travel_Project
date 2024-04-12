using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Controllers

namespace App.Controllers
{
    public class TopuriController : Controller
    {
        // GET: Topuri
        public ActionResult Index()
        {
            return View();
        }
    }
}