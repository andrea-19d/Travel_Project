using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class MyProfilePageController : Controller
    {
        // GET: MyProfilePage
        public ActionResult MyProfile()
        {
            return View();
        }
    }
}