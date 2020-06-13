using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace UI.Security
{
    //This class Defines the necessary properties which we will pass across the application
    public class CustomPrincipal : IPrincipal
    {
        //Receive the UserName and based upon the UserName we will Initialise the Identity
        public CustomPrincipal(string Username)
        {
            Identity = new GenericIdentity(Username);
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string[] Roles { get; set; }

        public IIdentity Identity { private set; get; }

        //Used for checking the role of the user i.e. Admin role or User Role at AuthorizationFilter
        public bool IsInRole(string role)
        {
            //Roles that we have in our application
            //Role contain this UserRole

            //Getting exception here as Roles is coming null
            if (Roles.Any(r => role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}