using BusinessLogic.Interfaces;
using Domain.Entities.Enums;
using App.Extension;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Net.Http;
using System;

namespace App.Controllers.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AdminModAttribute : ActionFilterAttribute
    {
        public enum HttpMethod
        {
            Get,
            Post,
            Put,
            Delete
        }


        private readonly ISession _session;
        private readonly HttpMethod[] _allowedHttpMethods;

        public AdminModAttribute(params HttpMethod[] allowedHttpMethods)
        {
            _allowedHttpMethods = allowedHttpMethods;
            var businessLogic = new BusinessLogic.BussinesLogic();
            _session = businessLogic.GetSessionBL();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (_allowedHttpMethods == null || _allowedHttpMethods.Length == 0)
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            var httpMethod = filterContext.HttpContext.Request.HttpMethod.ToUpper();
            var isMethodAllowed = false;

            foreach (var allowedMethod in _allowedHttpMethods)
            {
                if (httpMethod == allowedMethod.ToString().ToUpper())
                {
                    isMethodAllowed = true;
                    break;
                }
            }

            if (!isMethodAllowed)
            {
                RedirectToErrorAccessDenied(filterContext);
                return;
            }

            var apiCookie = HttpContext.Current.Request.Cookies["X-KEY"];
            if (apiCookie == null)
            {
                RedirectToLogin(filterContext);
                return;
            }

            var profile = _session.GetUserByCookie(apiCookie.Value);
            if (profile == null || profile.Level != LevelAcces.Admin)
            {
                RedirectToErrorAccessDenied(filterContext);
                return;
            }

            HttpContext.Current.SetMySessionObject(profile);

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

        private void RedirectToErrorAccessDenied(ActionExecutingContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new { controller = "Home", action = "ErrorAccessDenied" }));
        }

    }
}