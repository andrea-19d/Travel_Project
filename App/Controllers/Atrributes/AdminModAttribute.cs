﻿using App.Extension;
using BusinessLogic.Interfaces;
using Domain.Entities.Enums;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace proiect.Attributes
{
    public class AdminModAttribute : ActionFilterAttribute
    {
        private readonly ISession _sessionBusinessLogic;

        public AdminModAttribute()
        {
            var businessLogic = new BusinessLogic.BussinesLogic();
            _sessionBusinessLogic = businessLogic.GetSessionBL();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var apiCookie = HttpContext.Current.Request.Cookies["X-KEY"];
            if (apiCookie == null)
            {
                RedirectToLogin(filterContext);
                return;
            }

            var profile = _sessionBusinessLogic.GetUserByCookie(apiCookie.Value);
            if (profile == null)
            {
                RedirectToLogin(filterContext);
                return;
            }

            if (profile.Level == LevelAcces.Admin)
            {
                HttpContext.Current.SetMySessionObject(profile);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Home", action = "ErrorAccessDenied" }));
            }
        }

        private void RedirectToLogin(ActionExecutingContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new { controller = "LogInPage", action = "LogIn" }));
        }
    }
}
