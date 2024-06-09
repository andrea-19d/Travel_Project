using App.Models;
using AutoMapper;
using BusinessLogic;
using BusinessLogic.DBModel.Seed;
using BusinessLogic.Interfaces;
using Domain.Entities.Bookings;
using Domain.Entities.Enums;
using Domain.Entities.Res;
using dotless.Core.Parser.Functions;
using proiect.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IMonitoring _monitoring;
        private readonly ISession _session;
        private readonly IProduct _product;
        private readonly BookingContext _context;


        public AdminController()
        {
            var bl = new BussinesLogic();
            var context = new BookingContext();
            _monitoring = bl.GetMonitoringBL();
            _session = bl.GetSessionBL();
            _product = bl.GetProductBL();
            _context = context;
        }

        [AdminMod]
        public ActionResult Admin()
        {
            var NrOfUsers = _monitoring.ManageNrOfUsers();
            var NrOfNewUsers = _monitoring.TodaysUsers();
            var UsersPercentage = _monitoring.GetUserPercentage();
            var TodaysSales = _monitoring.TodaysSales();
            var TotalSales = _monitoring.TotalSales();
            var SalesPercentage = _monitoring.GetSalesPercentage();

            ViewBag.NrOfUsers = NrOfUsers;
            ViewBag.NrOfTodaysUsers = NrOfNewUsers;
            ViewBag.TodaysSales = TodaysSales;  
            ViewBag.TotalSales = TotalSales;    
            ViewBag.UsersPercentage = UsersPercentage;
            ViewBag.SalesPercentage = SalesPercentage;

            return View(NrOfUsers);
        }

        [AdminMod]
        public ActionResult Index()
        {
            SessionStatus();

            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("", "Login");
            }
            return View();
        }

        [AdminMod]
        [HttpGet]
        public ActionResult Billing()
        {
            SessionStatus();
            var billingInformation = _product.GetAllPendingBookings();
            return View(billingInformation);
        }

        [HttpGet]
        public ActionResult Tables()
        {
            var allUsers = _monitoring.GetCount();
            var onlineThreshold = DateTime.Now.AddMinutes(-5);

            foreach (var user in allUsers)
            {
                user.IsOnline = user.LastLogin > onlineThreshold;
            }
            return View(allUsers);
        }


        [AdminMod]
        public ActionResult DeleteUser(int id)
        {
            ActionStatus status = _monitoring.DeleteUser(id);
            ViewBag.Status = status.Status;
            return RedirectToAction("Tables");
        }


        [HttpPost]
        public ActionResult ChangeRole( int id, string newUserRole)
        {
           
                LevelAcces status = _monitoring.ChangeUserRole(id, newUserRole);
                ViewBag.Status = status.ToString();
                return RedirectToAction("Tables");
        }


        [HttpGet]
        public async Task<ActionResult> Destinations()
        {
            var allDestinations = await _product.GetPackages();
            return View(allDestinations);
        }

        [HttpGet]
        public ActionResult EditDestination(int ID)
        {
            var destination = _product.GetADestination(ID);
            return View(destination);

        }


        // POST: EditDestination
        [HttpPost]
        [Route("Create")]
        public ActionResult UpdateDest(ADestinations destination)
        {
            HttpPostedFileBase file = Request.Files["destinationPicture"];

            if (ModelState.IsValid)
            {
                var updateDestination = Mapper.Map<ADestinations>(destination);

                if (updateDestination != null)
                {
                    ActionStatus resp = _product.UpdateDestination(updateDestination, file);
                    if (resp.Status)
                    {
                        return RedirectToAction("Destinations");
                    }
                }
            }

            return View(destination);
        }

        [AdminMod]
        public ActionResult DeleteDestination(int id)
        {
            ActionStatus destinationStatus = _monitoring.DeleteDestination(id);
            if (destinationStatus.Status)
            {
                ViewBag.Status = destinationStatus.StatusMessage;
                return RedirectToAction("Destinations");
            }
                return RedirectToAction("Destinations");
        }


        [AdminMod]
        public ActionResult AddDestinations()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDestinations(aDestination data)
        {

            HttpPostedFileBase file = Request.Files["destinationPicture"];

            if (ModelState.IsValid)
            {
                var destination = Mapper.Map<ADestinations>(data);

                ActionStatus resp = _monitoring.AddDestination(destination, file);

                if (resp.Status)
                {
                    ViewBag.Message = resp.StatusMessage;
                    return RedirectToAction("AddDestinations", "Admin");
                }
                else
                {
                    ViewBag.Message = resp.StatusMessage;
                    return View(data);
                }
            }
            return View(data);
        }

/* ---TO DO: UPDATE THE CHART SO THAT IT MATCHES THE NECESSARY DATA--- */

        [HttpGet]
        public ActionResult GetUpdatedData()
        {
            // Logic to fetch updated data
            var updatedData = new { NrOfUsers = _monitoring.GetCount() };
            return Json(updatedData, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CHART()
        {
            var salesData = _context.Bookings
                                   .GroupBy(b => new { b.CreationDate.Year, b.CreationDate.Month })
                                   .Select(g => new
                                   {
                                       Year = g.Key.Year,
                                       Month = g.Key.Month,
                                       TotalSales = g.Sum(b => b.TotalPrice)
                                   })
                                   .ToList();

            return Json(salesData, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult DestinationsChart()
        {
            var destData = _context.Bookings
                .GroupBy(b => new { b.DestinationID })
                .Select(g => new
                {
                    DestinationID = g.Key.DestinationID,
                    DestinationName = g.FirstOrDefault().DestinationName, // Assuming you have a navigation property to the destination table
                    BookingCount = g.Count()
                })
                .OrderByDescending(x => x.BookingCount) // Order by booking count in descending order
                .Take(10) // You can adjust the number of destinations you want to display
                .ToList();

            return Json(destData, JsonRequestBehavior.AllowGet);
        }


    }
}
