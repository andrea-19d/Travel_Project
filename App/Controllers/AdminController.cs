using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.Web.Controllers.Attributes;
//using AutoMapper;
using App.Models;

namespace App.Controllers
{

    public class AdminController : BaseController
    {
        [AdminMod]
        public ActionResult Editor()
        {
            return View();
        }
        [AdminMod]
        public ActionResult Index()
        {
            SessionStatus();

            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
            {

                return RedirectToAction("Index", "Login");
            }
            return View();


        }

    }
}