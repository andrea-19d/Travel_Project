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

            /*ANOTHER TRY */
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     "~/Scripts/jquery-{version}.js"));

            // Add your custom script bundles here
            bundles.Add(new ScriptBundle("~/bundles/admin-js").Include(
                        "~/Content/ADMIN/assets/js/argon-dashboard.min.js",
                        "~/Content/ADMIN/assets/js/core/popper.min.js",
                   
                        "~/Content/ADMIN/assets/js/plugins/perfect-scrollbar.min.js",
                        "~/Content/ADMIN/assets/js/plugins/smooth-scrollbar.min.js",
                        "~/Content/ADMIN/assets/js/plugins/chartjs.min.js"
                        ));

            // Bundle for Bootstrap CSS
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap-theme.css"
                        ));

            // Bundle for Argon Dashboard CSS
            bundles.Add(new StyleBundle("~/Content/admin-css").Include(
                        "~/Content/ADMIN/assets/css/argon-dashboard.min.css"
                        ));


            bundles.Add(new StyleBundle("~/bundles/admin-css").Include(
                    "~/Content/ADMIN/assets/css/nucleo-icons.css",
                    "~/Content/ADMIN/assets/css/nucleo-svg.css",
                    "~/Content/ADMIN/assets/css/argon-dashboard.css?v=2.0.4"
                    ));
            /*END OF THE TRY */

            // Styles 
            bundles.Add(new StyleBundle("~/bundle/owlcarousel/css").Include(
                "~/Content/lib/owlcarousel/assets/owl.carousel.min.css"));
            bundles.Add(new StyleBundle("~/bundle/lightbox/css").Include(
                "~/Content/lib/lightbox/css/lightbox.min.css"));
            bundles.Add(new StyleBundle("~/bundle/bootstrap/min/css").Include(
                "~/Content/css/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/bundle/style/css").Include(
                "~/Content/css/style.css"));

            bundles.Add(new StyleBundle("~/bundles/register/css").Include(
                "~/Content/css/Register.css"));
            bundles.Add(new StyleBundle("~/bundle/login/css").Include(
                "~/Content/css/LogIn.css"));
            bundles.Add(new StyleBundle("~/bundle/accountSettings/css").Include(
                "~/Content/css/AcountSettings.css"));

            BundleTable.EnableOptimizations = true;

        }
    }
}
