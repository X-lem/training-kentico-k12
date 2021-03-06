using System;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;
using System.Web.UI.WebControls;
using CMS.DocumentEngine;
using Kentico.Web.Mvc;
using MedioClinic.Config;
using MedioClinic.Utils;

namespace MedioClinic
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var defaultCulture = CultureInfo.GetCultureInfo("en-US");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Use lowercase urls for consistency
            routes.LowercaseUrls = true;

            // Map routes to Kentico HTTP handlers first as some Kentico URLs might be matched by the default ASP.NET MVC route resulting in displaying pages without images
            routes.Kentico().MapRoutes();

            // Maps the Not found route (the route needs to be registered separately to allow cultureless url)
            routes.MapRoute(
                "NotFound",
                "notfound",
                new { controller = "NotFound", action = "Index" }
            );

            // Maps route to doctor detail
            var route = routes.MapRoute(
                name: "DoctorWithAlias",
                url: "{culture}/Doctors/Detail/{nodeGuid}/{nodeAlias}",
                defaults: new { action = "Detail", controller = "Doctors", culture = defaultCulture.Name, nodeGuid = string.Empty, nodeAlias = "" },
                constraints: new { culture = new SiteCultureConstraint(AppConfig.Sitename), nodeGuid = new GuidRouteConstraint(), nodeAlias = new OptionalRouteConstraint(new AlphaRouteConstraint()) }
            );

            // Maps route to school detail
            route = routes.MapRoute(
                name: "SchoolWithAlias",
                url: "{culture}/Schools/Detail/{nodeGuid}/{nodeAlias}",
                defaults: new { action = "Detail", controller = "Schools", culture = defaultCulture.Name, nodeGuid = string.Empty, nodeAlias = "" },
                constraints: new { culture = new SiteCultureConstraint(AppConfig.Sitename), nodeGuid = new GuidRouteConstraint(), nodeAlias = new OptionalRouteConstraint(new AlphaRouteConstraint()) }
            );

            // Maps route to article detail
            route = routes.MapRoute(
                name: "ArticleWithAlias",
                url: "{culture}/Articles/Detail/{nodeGuid}/{nodeAlias}",
                defaults: new { action = "Detail", controller = "Articles", culture = defaultCulture.Name, nodeGuid = string.Empty, nodeAlias = "" },
                constraints: new { culture = new SiteCultureConstraint(AppConfig.Sitename), nodeGuid = new GuidRouteConstraint(), nodeAlias = new OptionalRouteConstraint(new AlphaRouteConstraint()) }
            );

            // Maps route to langing pages
            route = routes.MapRoute(
                name: "LandingPage",
                url: "{culture}/LandingPage/{nodeAlias}",
                defaults: new { culture = defaultCulture.Name, controller = "LandingPage", action = "Index" },
                constraints: new { culture = new SiteCultureConstraint(AppConfig.Sitename), nodeAlias = new OptionalRouteConstraint(new RegexRouteConstraint(@"[\w\d_-]*")) }
            );

            // A route value determines the culture of the current thread
            route.RouteHandler = new MultiCultureMvcRouteHandler();

            // Maps routes with cultures
            route = routes.MapRoute(
                name: "DefaultWithCulture",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new { culture = defaultCulture.Name, controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { culture = new SiteCultureConstraint(AppConfig.Sitename), id = new OptionalRouteConstraint(new IntRouteConstraint()) }
            );

            // A route value determines the culture of the current thread
            route.RouteHandler = new MultiCultureMvcRouteHandler();
        }

        private static void HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }
}