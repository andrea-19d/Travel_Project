﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult About()
        {
            Console.WriteLine(View());
            return View();
        }
    }
}