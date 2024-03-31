// LogInPageController.cs

using System;
using System.Web.Mvc;
using BusinessLogic;
using App.Models;
using BusinessLogic.Interfaces;
using Domain.Entities.User;
using System.Web.Security;

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
                    Email = login.Email,
                    Password = login.Password,
                    LoginDateTime = DateTime.Now,
                };

                var userLogin = _session.UserLogin(data);

                if (userLogin.Status)
                {
                    FormsAuthentication.SetAuthCookie(login.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Login failed, add error message to ModelState
                    ViewBag.ErrorMessage = userLogin.StatusMessage;
                }
            }

            // If ModelState is not valid or login is unsuccessful, return to login view with error messages
            return View(login);
        }
    }
}
