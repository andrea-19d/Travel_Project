using App.Controllers.Atrributes;
using App.Models;
using AutoMapper;
using BusinessLogic;
using BusinessLogic.DBModel.Seed;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class BookingPageController : BaseController
    {
        private readonly ISession _session;
        private readonly IProduct _product;

        public BookingPageController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
            _product = bl.GetProductBL();
        }

        // GET: BookingPage
        [UserMod]
        public ActionResult Index()
        {
            SessionStatus();

            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("", "Login");
            }
            return View();
        }


        [UserMod]
        [HttpGet]
        public ActionResult Booking(int id)
        {
            SessionStatus();
            var currentUserEmail = Session["Username"].ToString();
            var user = _session.GetCurrentUser(currentUserEmail);
            if (user == null)
            {
                return View();
            }
            var currentDestination = _product.GetADestination(id);
            ViewData["userId"] = user.UserId;
            ViewBag.firstName = user.FirstName;
            ViewBag.lastName = user.LastName;
            ViewBag.email = user.Email;


            return View(currentDestination);
        }

        [HttpPost]
        public ActionResult UCreateBooking(int destinationID, int userId, int nrOfPeople)
        {
            var destination = _product.CreateBooking(destinationID, userId, nrOfPeople);
            if (destination.Status)
            {
                ViewBag.Message = destination.StatusMessage;
                return RedirectToAction("Packages", "PackagesPage");
            }
            return View("Booking");
        }

    }
}