using App.Models;
using BusinessLogic.Interfaces;
using BusinessLogic;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class RegisterPageController : Controller
    {
        private readonly ISession _session;

        public RegisterPageController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        // GET: LogInPage (assuming you want to display the login form initially)
        public ActionResult Register()
        {
            return View();
        }

        public void Usera()
        {
            var credential = "dsadsa";
            var password = "password";
            var data = new userLogin
            {
                Credential = credential,
                Password = password,
            };
            Register(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(userLogin login)
        {
            Usera();
            if (ModelState.IsValid)
            {
                // Assuming userLogin is a model representing user credentials (email and password)
                ULoginData data = new ULoginData
                {
                    Credential = "andrea",
                    Password = "12345",
                    LoginIp = "1.1.1.1",
                    LoginDateTime = DateTime.Now,
                };
                RResponseData resp = _session.RegisterNewUserAction(regData);

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