using App.Models;
using dotless.Core.Parser.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            string role = SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return View();
            }
            return View();
        }

        public ActionResult About()
        {
            string role = SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return View();
            }
            return View();
        }

        public ActionResult AccountSettings()
        {
            string role = SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return View();
            }
            return View();
        }
    }
}