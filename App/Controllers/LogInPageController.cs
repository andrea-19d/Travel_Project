// LogInPageController.cs

using System;
using System.Web.Mvc;
using BusinessLogic;
using App.Models;
using BusinessLogic.Interfaces;
using Domain.Entities.User;

namespace App.Controllers
{
    public class LogInPageController : Controller
    {
        private readonly ISession _session;

        public LogInPageController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        // GET: LogInPage (assuming you want to display the login form initially)
        public ActionResult LogIn()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(userLogin login)
        {
            if (ModelState.IsValid)
            {
                // Assuming userLogin is a model representing user credentials (email and password)
                ULoginData data = new ULoginData
                {
                    Credential = login.Credential,
                    Password = login.Password,
                    LoginIp = Request.UserHostAddress,
                    LoginDateTime = DateTime.Now,
                };

                var userLogin = _session.UserLogin(data);

                if (userLogin.Status)
                {
                    // Successfully logged in, redirect to home or dashboard
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Login failed, add error message to ModelState
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // If ModelState is not valid or login is unsuccessful, return to login view with error messages
            return View(login);
        }
    }
}
