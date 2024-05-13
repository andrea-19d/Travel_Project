using App.Extension;
using BusinessLogic.Interfaces;
using Domain.Entities.Enums;
using System;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace App.Controllers.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AdminModAttribute : ActionFilterAttribute
    {
        internal const object HttpMethod;
        private readonly ISession _session;
        private readonly HttpMethod[] _allowedHttpMethods;

        public AdminModAttribute(params HttpMethod[] allowedHttpMethods)
        {
            _allowedHttpMethods = allowedHttpMethods;
            _session = DependencyResolver.Current.GetService<ISession>();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (_allowedHttpMethods == null || !_allowedHttpMethods.Any())
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            var httpMethod = filterContext.HttpContext.Request.HttpMethod.ToUpper();
            if (!_allowedHttpMethods.Select(m => m.ToString().ToUpper()).Contains(httpMethod))
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
