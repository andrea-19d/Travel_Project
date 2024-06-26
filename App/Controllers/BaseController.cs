﻿using App.Extension;
using BusinessLogic.Interfaces;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities.Enums;

namespace App.Controllers
{
    public class BaseController : Controller
    {
        private readonly ISession _session;
        public BaseController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        public string SessionStatus()
        {
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                if (profile != null)
                {
                    System.Web.HttpContext.Current.SetMySessionObject(profile);
                    System.Web.HttpContext.Current.Session["LoginStatus"] = "login";
                    System.Web.HttpContext.Current.Session["Username"] = profile.Username;
                    if (profile.Level == LevelAcces.Admin)
                        return "Admin";
                    return "User";
                }
                else
                {
                    ClearSessionAndCookie();
                    return "None";
                }
            }
            else
            {
                System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
                return "None";
            }
        }

        private void ClearSessionAndCookie()
        {
            System.Web.HttpContext.Current.Session.Clear();
            if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("X-KEY"))
            {
                var cookie = ControllerContext.HttpContext.Request.Cookies["X-KEY"];
                if (cookie != null)
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                }
            }
            System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
        }

    }
}