using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class BookingPageController : Controller
    {
        // GET: BookingPage
        [HttpGet]
        public ActionResult Booking()
        {
            var currentUser = Session["Username"].ToString();

            return View();
        }
    }
}