using DomainModels.ViewModels;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UI.Controllers
{

    //Implementing DI using Inheritance BaseController
    public class AccountController : BaseController
    {
        // IUnitOfWork uow;
        public AccountController(IUnitOfWork _uow) : base(_uow)
        {
            uow = _uow;
            // uow = new UnitOfWork();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        //From the cookie, we will find out the logged-in user.
        //Advantage of this would be we will not need to maintain the session now for passing the Logged In user information across the session.
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserViewModel user = uow.AuthenticateRepository.ValidateUser(model);
                if (user != null)
                {
                    #region Logic for creating an encrypted ticket and adding it to the client-side in the form of cookie
                    //From this cookie, we will find out the logged-in user.
                    //Advantage of this would be we will not need to maintain the session now for passing the Logged In user information across the session.

                    //Create the form Authentication ticket
                    //Currently the User Info is in an object so Convert the Users info into String by serializing the User object in the string so for this use NewtonSoft.
                    string data = JsonConvert.SerializeObject(user);

                    #region Info about FormsAuthenticationTicket
                    // Summary:Initializes a new instance of the System.Web.Security.FormsAuthenticationTicket
                    //     class with cookie name, version, directory path, issue date, expiration date,
                    //     persistence, and user-defined data.

                    //   version: The version number of the ticket.
                    //   name: The user name associated with the ticket.
                    //   issue date: The local date and time at which the ticket was issued.
                    //   expiration: The local date and time at which the ticket expires.
                    //   is persistent: true if the ticket will be stored in a persistent cookie (saved across browser
                    //     sessions); otherwise, false. If the ticket is stored in the URL, this value is ignored.
                    //   userData: The user-specific data to be stored with the ticket.
                    #endregion

                    //public FormsAuthenticationTicket(int version, string name, DateTime issueDate, DateTime expiration, bool isPersistent, string userData, string userData);
                    //isPersistent: If user has check the Checkbox lets say Remember Me, so in this case to implement this functionality
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.Username, DateTime.Now, DateTime.Now.AddMinutes(20), false, data);

                    //Now we will encrypt the ticket and we are doing this because in the FormsAuthentication we are using the cookies for storing the Logged-In User information, and to this cookie, we will pass this encrypted Ticket.
                    string encTicket = FormsAuthentication.Encrypt(ticket);

                    //FormsAuthentication.FormsCookieName: CookieName will be picked up from the Web.config name="MVCAngularProject"
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

                    //Now add the cookie to the response object
                    Response.Cookies.Add(cookie);

                    //From this cookie, we will find out the logged-in user.
                    //Advantage of this would be we will not need to maintain the session now for passing the Logged In user information across the session.
                    #endregion

                    if (user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "User" });
                    }
                }
            }
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult UnAuthorize()
        {
            return View();
        }
    }
}