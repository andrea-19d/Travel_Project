using Microsoft.ApplicationInsights.Extensibility.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.DBModel.Seed;

namespace App.Controllers
{
    public class MyProfilePageController : Controller
    {
        private BusinessLogic.DBModel.Seed.UserContext _userContext; // Assuming you have a DbContext configured

        public MyProfilePageController()
        {
            _userContext = new BusinessLogic.DBModel.Seed.UserContext();
        }


        [HttpGet]
        public ActionResult MyProfile()
        {
            // Fetch additional user information from the database
            var currentUser = User.Identity.Name;
            var user = _userContext.Users.FirstOrDefault(u => u.Email == currentUser);

            if (user != null)
            {
                ViewBag.Username = user.Credentials;
                ViewBag.Email = user.Email;
                ViewBag.Role = user.level;
            }

            return View();
        }
    }
}