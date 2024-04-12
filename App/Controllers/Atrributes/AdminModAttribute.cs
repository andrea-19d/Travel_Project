using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BusinessLogic.Interfaces;
using BusinessLogic;
using BusinessLogic.Interfaces;
using Domain.Entities.Enums;
using Extensions;

namespace eUseControl.Web.Controllers.Attributes
{
    public class AdminModAttribute : ActionFilterAttribute
    {
        private readonly ISession _sessionBL;

        public AdminModAttribute()
        {
            var businessLogic = new BusinessLogic.BussinesLogic();
            _sessionBL = businessLogic.GetSessionBL();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var apiCookie = HttpContext.Current.Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _sessionBL.GetUserByCookie(apiCookie.Value);
                if (profile != null && profile.Level == URole.Admin)
                {
                    HttpContext.Current.SetMySessionObject(profile);
                }
                else
                {
                    /*filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                         controller = "Home",
                         action = "Index"
                    }));*/
                    filterContext.Result = new RedirectToRouteResult(new
                                                       System.Web.Routing.RouteValueDictionary(new { controller = "Home", action = "Error404" }));
                }
            }
        }
    }
}