﻿using System.Web.Optimization;

namespace NorthWind2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/jquery.cookie.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/cssbundles").Include(
                      
                      "~/Content/site.*",
                      "~/Content/ngNotificationsBar.min.css"));

           // bundles.Add(new ScriptBundle("~/bundles/ng-bundle").Include(
           //"~/Scripts/angularApp/app.js",
           // "~/Scripts/factories/cartrepository.js",
           // "~/Scripts/angularController/cartController.js",
           // "~/Scripts/factories/userservice.js" 
           // ));
        }
    }
}
