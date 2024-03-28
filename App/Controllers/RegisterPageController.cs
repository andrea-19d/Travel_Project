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
    }
}
