using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using WEBAPIMVC.ErrorLog;
using WEBAPIMVC.Services;

namespace WEBAPIMVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Rachit
            config.Filters.Add(new LogCustomExceptionFilterAPI());

            //var container = new UnityContainer();
            //container.RegisterType<IContact, ContactRepository>(new HierarchicalLifetimeManager());

            //config.DependencyResolver = new UnityResolver(container);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
