using App.Models;
using BusinessLogic;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class BookingPageController : Controller
    {
        private readonly ISession _session;
        private readonly IProduct _product;

        public BookingPageController()
        {
            var bl = new  BussinesLogic();
            _session = bl.GetSessionBL();
            _product = bl.GetProductBL();
        }



        // GET: BookingPage
        [HttpGet]
        public ActionResult Booking(int id)
        {
           /* var currentUserEmail = Session["Username"].ToString();*/
           /* var user = _session.GetCurrentUser(currentUserEmail);
            if (user == null) 
            {
                return View();
            }*/
            var currentDestination = _product.GetADestination(id);




            return View(currentDestination);
        }
    }
}