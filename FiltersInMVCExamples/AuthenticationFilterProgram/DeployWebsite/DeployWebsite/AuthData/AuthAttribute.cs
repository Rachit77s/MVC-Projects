using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace DeployWebsite.AuthData
{
    public class AuthAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        private bool _auth;
        //The IAuthenticationFilter interface defines two methods: OnAuthentication and OnAuthenhenticationChallenge
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //throw new NotImplementedException();
            _auth = (filterContext.ActionDescriptor.GetCustomAttributes( typeof(OverrideAuthenticationAttribute), true ).Length == 0 );
        }

        //Runs after the OnAuthentication method    
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //throw new NotImplementedException();

            var user = filterContext.HttpContext.User;

            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }


        }
    }
}