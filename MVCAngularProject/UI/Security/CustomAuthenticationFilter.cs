using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
namespace UI.Security
{
    public class CustomAuthenticationFilter : FilterAttribute, IAuthenticationFilter
    {
        //Below method Can be used for Authenticity
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //Check the Identity which we have set here
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        //Below method Can be used for redirecting the user
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
           if(filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Account", action = "login", area=""}));
            }
        }
    }
}