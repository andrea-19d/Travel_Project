using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class GalleryPageController : Controller
    {
        // GET: GalleryPage
        public ActionResult Gallery()
        {
            return View();
        }
    }
}