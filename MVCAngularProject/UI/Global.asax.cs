using DomainModels.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using UI.Security;

namespace UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();                           // <----- Add this line for DI
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        //This function will be called everytime user makes a request to the server.
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            //Get the cookie name
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                //Get the ticket from the cookie value by decrypting the cookie
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                //Check the ticket expiry, if expired dont proceed further
                if (!ticket.Expired)
                {
                    //We have earlier serialized the User information in the JSON format hence we will deserialize the USer Info
                    UserViewModel model = JsonConvert.DeserializeObject<UserViewModel>(ticket.UserData);

                    //Rachit: Because role is not populating hence did this fix.
                    //Due to not able to get the Role
                    if (model.Username.Contains("admin"))
                    {
                        var adminRole = new[] { "Admin" };
                        model.Roles = adminRole;
                    }
                    else
                    {
                        var userRole = new[] { "User" };
                        model.Roles = userRole;
                    }


                    //Now in FormsAuthentication we have the UserContext and the UserContext contains the Principal inside it andthis  Principal contains the Identity(ForAuthentication) and Roles(ForAuthorization) 
                    //Hence we will need to create the custom Princpal here and we will set it to the UserContext as theHttpContext  expects the IPrincipal object
                    CustomPrincipal user = new CustomPrincipal(model.Username);
                    user.UserId = model.UserId;
                    user.Username = model.Username;
                    user.Name = model.Name;
                    user.Roles = model.Roles;
                    user.ContactNo = model.ContactNo;

                    //Setting the current user to HttpContext   
                    //Hence now where ever we need user information we will access it from the HttpContext
                    HttpContext.Current.User = user;

                    //Also we can access HttpContext information across all our Views by defining the Base Page for our Views i.e.  <pages pageBaseType="System.Web.Mvc.WebViewPage"> in Views Web.Config
                }
                else
                {
                    //User is not logged-in or if ticket is expired
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Account/Login");
                }
            }
        }
    }
}
