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
        public ActionResult Booking()
        {
            UserData u = new UserData();
            u.UserName = "Customer";
            u.Products = new List<string> { "Booking 1", "Booking 3" };
            return View(u);
        }
    }
}