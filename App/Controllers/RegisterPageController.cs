﻿using App.Models;
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
using AutoMapper;
using System.IO;


namespace App.Controllers
{
    public class RegisterPageController : BaseController
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
            SessionStatus();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(userRegister registerData)
        {

            if (ModelState.IsValid)
            {
                var registredUser = Mapper.Map<URegisterData>(registerData);
                registredUser.UserIP = Request.UserHostAddress;

                var userRegister = _session.RegisterNewUserAction(registredUser);
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