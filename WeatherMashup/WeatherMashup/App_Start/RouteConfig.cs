using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WeatherMashup
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        { 
            ErrorHandlingConfig.RegisterSpecificErrorHandlingRoutes(routes);

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "WeatherMashup", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                null,
                "manifest.appcache",
                new { controller = "Shared", action = "AppCacheManifest" });

            ErrorHandlingConfig.RegisterCatchAllErrorHandlingRoute(routes);
        }
    }
}