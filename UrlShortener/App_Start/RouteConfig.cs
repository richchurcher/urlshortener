using System.Web.Mvc;
using System.Web.Routing;

namespace UrlShortener
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new { controller = @"Urls" }
            );

            routes.MapRoute(
                "Shortener",
                "{shortformUrl}",
                new {controller = "Urls", action = "Go", shortformUrl = UrlParameter.Optional }
            );
        }

        //public class UrlShortenerRouteConstraint : IRouteConstraint
        //{
        //    public bool Match(HttpContextBase httpContext, Route route, string parameterName,
        //        RouteValueDictionary values, RouteDirection routeDirection)
        //    {
        //        var action = values["action"] as string;
        //        var controller = values["controller"] as string;

        //        var controllerFullName = string.Format("UrlShortener.Controllers.{0}Controller", controller);
        //        var cont = Assembly.GetExecutingAssembly().GetType(controllerFullName);
        //        return cont != null && cont.GetMethod(action) != null;
        //    }
        //}
    }
}
