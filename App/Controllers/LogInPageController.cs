using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using BusinessLogic;
using BusinessLogic.Interfaces;
using Domain.Entities.User.Global;
using Domain.Entities.User;
using App.Models;

namespace App.Controllers
{
    public class LogInPageController : Controller
    {
        // GET: LogInPage
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
                ULoginData data = new ULoginData
                {
                    Credential = login.Credential,
                    Password = login.Password,
                    LoginIp = Request.UserHostAddress,
                    LoginDateTime = DateTime.Now
                };
                var userLogin = _session.UserLogin(data);
                if(userLogin.Status) {
                    //ADD COKIE
                    LevelStatus status = _session.CheckLevel(userLogin.SessionKey);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Nume de utilizator sau parola sunt incorecte", userLogin.StatusMessage);
                    return View();
                }
                
            }
            return View();
        }
        
    }
}