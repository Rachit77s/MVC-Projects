using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services
            //config.EnableCors();

            //Remove reference loop 
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
  .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            //Remove XML return type from API result
            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
