using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "MoviesByReleaseDate",
               "movies/released/{year}/{month}" ,
                new { controller = "Movies", action = "ByReleaseDate"},
                new { year = @"\d{4}" , month = @"\d{2}"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

           // http://localhost:58446/Customers/CustomerForm
            //routes.MapRoute(
            //   "CustomersIndex",
            //  "Customers/CustomerForm",
            //   new { controller = "Customers", action = "Index" , id = UrlParameter.Optional });

            ////Here, our Route name is “MyCustomRoute” and if any user comes with the url starting with “MyEmployees”, this route serves the request.
            //routes.MapRoute(
            //    name: "MyCustomRoute",
            //    url: "Customers/{action}/{id}",
            //    defaults: new { controller = "Customers", action = "Index", id = UrlParameter.Optional });
        }
    }
}
