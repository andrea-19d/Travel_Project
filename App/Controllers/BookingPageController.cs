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
using Domain.Entities.Bookings;
using Domain.Entities.Res;

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
        public ActionResult Booking(int destinationId)
        {
            SessionStatus();
            var destination = _product.GetADestination(destinationId);
            var email = Session["Username"].ToString();
            var user = _session.GetCurrentUser(email);

            var viewModel = new BookingViewModel
            {
                DestinationID = destination.DestinationID,
                DestinationName = destination.DestinationName,
                NrOfPeople = destination.NrOfPeople,
                Price = destination.Price,
                Days = destination.Days,
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult UCreateBooking(BookingViewModel model)
        {
            SessionStatus();
            if (ModelState.IsValid)
            {
                var booking = Mapper.Map<UBooking>(model);

                ActionStatus resp = _product.CreateBooking(booking);
                if (resp.Status)
                {
                    ViewBag.BookingStatus = resp.Status;
                    return RedirectToAction("Packages", "PackagesPage");
                    /* --- TO DO: return RedirectToAction("BookingSuccess");*/
                }
            }

            return View(model);
        }

    }
}