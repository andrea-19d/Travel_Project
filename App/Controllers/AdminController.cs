using System;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic;
using Domain.Entities.Bookings;
using Domain.Entities.Res;
using App.Models;
using System.Net.Http;
using System.Collections.Generic;
using System.Security.Permissions;
using proiect.Attributes;

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
        public ActionResult Billing()
        {
            return View();
        }

        [AdminMod]
        public ActionResult Tables()
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

/*        [AdminMod]
        public ActionResult AddDestinations()
        {
            return View();
        }*/


        [AdminMod]
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
                    return View();
                }
                else
                {
                    ViewBag.Message = resp.StatusMessage;
                    return View(data);
                }
            }
            return View(data);
        }
    }
}
