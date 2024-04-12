using App.Models;
using BusinessLogic.Interfaces;
using BusinessLogic;
using Domain.Entities.User;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogic.Core;
using System.Runtime.InteropServices.WindowsRuntime;
using BusinessLogic.DBModel.Seed;
using System.Web.UI.WebControls;
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

        // GET: RegisterPage (assuming you want to display the registration form initially)
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(userRegister registerData)
        {
            if (ModelState.IsValid)
            {
                URegisterData data = new URegisterData
                {
                    Username = registerData.Username,
                    Email = registerData.Email,
                    Password = registerData.Password,
                    LastLogin = DateTime.Now,
                    level = registerData.level,

                };

                var userRegister = _session.RegisterNewUserAction(data);
                if (userRegister.Status)
                { 
                    ViewBag.SuccessMessage = userRegister.StatusMessage;
                    return RedirectToAction("LogIn", "LogInPage");
                }
                else
                {
                    ViewBag.ErrorMessage = userRegister.StatusMessage;
                }

                System.Diagnostics.Debug.WriteLine($"ViewBag.UserExists value: {ViewBag.UserExists}");
            }

            return View(registerData);
        }
    }
}