﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Web_Forum
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Thread",
                url: "Thread/{action}/{id}/{title}",
                defaults: new
                {
                    controller = "Thread",
                    action = "Index",
                    id = UrlParameter.Optional,
                    title = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
