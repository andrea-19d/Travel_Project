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
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IMonitoring _monitoring;
        private readonly ISession _session;
        private readonly IProduct _product;


        public AdminController()
        {
            var bl = new BussinesLogic();
            _monitoring = bl.GetMonitoringBL();
            _session = bl.GetSessionBL();
            _product = bl.GetProductBL();
        }

        [AdminMod]
        public ActionResult Admin()
        {

            var NrOfUsers = _monitoring.ManageNrOfUsers();
            var NrOfNewUsers = _monitoring.ManageNewUsersCount();

            ViewBag.NrOfUsers = NrOfUsers;
            ViewBag.NewUsersCount = NrOfNewUsers;

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
        public ActionResult Billing()
        {
            return View();
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
        public ActionResult Destinations()
        {
            var allDestinations = _product.GetPackages();
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
                        return RedirectToAction("EditDestination", new { ID = updateDestination.DestinationID });
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
    }
}
