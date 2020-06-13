using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace UI.Security
{
    public class CustomAuthorizationFilter : FilterAttribute, IAuthorizationFilter
    {
        public string Roles { get; set; }

        // We will check user permission and user roles
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //If there is no Role then we have to redirect to UnAuthorized
            if (!filterContext.HttpContext.User.IsInRole(Roles))
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Account", action = "UnAuthorize", area="" }));
            }
        }
    }
}