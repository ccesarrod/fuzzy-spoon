﻿using System.Web.Mvc;
using System.Web.Routing;

namespace NorthWind2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                 "DefaultApi", "api/{controller}/{id}",
                  new { id = UrlParameter.Optional }
             );
        }
    }
}
