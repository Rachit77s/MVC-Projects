using System.Web.Http;
using Unity;
using Unity.WebApi;
using WEBAPIMVC.Services;

namespace WEBAPIMVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            //Dependency Injection Injected from here by Unity.WebAPI
            container.RegisterType<IContact, ContactRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}