// LogInPageController.cs

using System;
using System.Web.Mvc;
using BusinessLogic;
using App.Models;
using BusinessLogic.Interfaces;
using Domain.Entities.User;
using System.Web.Security;
using System.Web;

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
                    Username = login.Username,
                    Password = login.Password,
                    LoginDateTime = DateTime.Now,
                };

                var userLogin = _session.UserLogin(data);

                if (userLogin.Status)
                {
                    FormsAuthentication.SetAuthCookie(login.Username, false);
                    HttpCookie cookie = _session.GenCookie(login.Username);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    Session["Username"] = login.Username;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Login failed, add error message to ModelState
                    ViewBag.ErrorMessage = userLogin.StatusMessage;
                    return View();
                }
            }
            return View(login);
        }
    }
}
