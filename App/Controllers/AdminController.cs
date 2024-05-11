using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Controllers.Attributes;
using AutoMapper;
using App.Models;
using System.EnterpriseServices;
using BusinessLogic.Interfaces;
using BusinessLogic;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using Domain.Entities.Bookings;
using Domain.Entities.Res;

namespace App.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IMonitoring _monitoring;
        private readonly ISession _session;

        public AdminController()
        {
            var bl = new BussinesLogic();
            _monitoring = bl.GetMonitoringBL();
            _session = bl.GetSessionBL();
        }
        
        [AdminMod]
        public ActionResult Admin()
        {
            SessionStatus();

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

            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
            {

                return RedirectToAction("", "Login");
            }
            return View();


        }
        
        [AdminMod]
        public ActionResult billing() 
        {
            return View();
        }


        [AdminMod]
        public ActionResult tables()
        {
            SessionStatus();
            var allUsers = _monitoring.GetCount();
            var onlineStatuses = new Dictionary<int, bool>();

            foreach (var user in allUsers)
            {
                var isOnline = (DateTime.Now - user.LastLogin).TotalMinutes < 1;

                onlineStatuses.Add(user.Id, isOnline);
            }
            ViewBag.OnlineStatuses = onlineStatuses;

            return View(allUsers);
        }

/*TO DO CAUSE IT AIN'T WORKING */
        public ActionResult addDestination(aDestination data)
        {
            SessionStatus();
            HttpPostedFileBase file = Request.Files["destinationPicture"];
            if (ModelState.IsValid)
            {
                var destination = Mapper.Map<ADestinations>(data);

                ActionStatus resp = _monitoring.AddDestination(destination, file);

                if (resp.Status)
                {
                    ViewBag.Message = resp.StatusMessage;
                    // Redirect to a different action after successful submission
                    return View(); // Redirect to the GET action
                }
                else
                {
                    ViewBag.Message = resp.StatusMessage;
                    // Return the same view if there's an error
                    return View(data); // Pass data back to the view
                }
            }
            // Return the same view if model state is not valid
            return View(data);
        }

        [AdminMod]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addDestinations(aDestination data)
        {
            SessionStatus();
            HttpPostedFileBase file = Request.Files["destinationPicture"];
            if (ModelState.IsValid)
            {
                var destination = Mapper.Map<ADestinations>(data);

                ActionStatus resp = _monitoring.AddDestination(destination, file);

                if (resp.Status)
                {
                    ViewBag.Message = resp.StatusMessage;
                    // Redirect to a different action after successful submission
                    return View(); // Redirect to the GET action
                }
                else
                {
                    ViewBag.Message = resp.StatusMessage;
                    // Return the same view if there's an error
                    return View( data); // Pass data back to the view
                }
            }
            // Return the same view if model state is not valid
            return View( data);
        }
    }
}