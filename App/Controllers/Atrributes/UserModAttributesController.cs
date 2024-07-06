using App.Extension;
using BusinessLogic.Interfaces;
using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace App.Controllers.Atrributes
{
    public class UserModAttribute : ActionFilterAttribute
    {
        // GET: UserModAttributes
        private readonly ISession _session;

        public UserModAttribute()
        {
            var businessLogic = new BusinessLogic.BussinesLogic();
            _session = businessLogic.GetSessionBL();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var apiCookie = HttpContext.Current.Request.Cookies["X-KEY"];
            if (apiCookie == null)
            {
                RedirectToLogin(filterContext);
                return;
            }

            var profile = _session.GetUserByCookie(apiCookie.Value);
            if (profile == null)
            {
                RedirectToLogin(filterContext);
                return;
            }

            if ((profile.Level == LevelAcces.User || profile.Level == LevelAcces.Admin))
            {
                HttpContext.Current.SetMySessionObject(profile);
            }
         /*   else
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "LogInPage", action = "AccountBlock" }));

            }*/
        }

        private void RedirectToLogin(ActionExecutingContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new { controller = "LogInPage", action = "LogIn" }));
        }
    }
}
    