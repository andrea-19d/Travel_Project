using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using System.Web.UI;

namespace App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Scripts 
            bundles.Add(new ScriptBundle("~/bundle/easing").Include(
                "~/Content/lib/easing/easing.min.js"));
            bundles.Add(new ScriptBundle("~/bundle/waypoints").Include(
                "~/Content/lib/waypoints/waypoints.min.js"));
            bundles.Add(new ScriptBundle("~/bundle/owlcarousel").Include(
                "~/Content/lib/owlcarousel/owl.carousel.min.js"));
            bundles.Add(new ScriptBundle("~/bundle/lightbox").Include(
                "~/Content/lib/lightbox/js/lightbox.min.js"));
            bundles.Add(new ScriptBundle("~/bundle/main").Include(
                "~/Content/js/main.js"));

            // Styles 
            bundles.Add(new StyleBundle("~/bundle/owlcarousel/css").Include(
                "~/Content/lib/owlcarousel/assets/owl.carousel.min.css"));
            bundles.Add(new StyleBundle("~/bundle/lightbox/css").Include(
                "~/Content/lib/lightbox/css/lightbox.min.css"));
            bundles.Add(new StyleBundle("~/bundle/bootstrap/min/css").Include(
                "~/Content/css/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/bundle/style/css").Include(
                "~/Content/css/style.css"));

            BundleTable.EnableOptimizations = true;

        }
    }
}
