using FiltersExample.DataAccess.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FiltersExample.Attributes
{
    //We want our filter to check the Session["CurrentUserID"] value against the Report ID, and see if the current user created the specified report. If s/he did, we proceed as normal, and if not, we redirect back to Home/Index.
    public class CanEditReport : ActionFilterAttribute
    {
        //What we want to do in this scenario is evaluate the CurrentUserID BEFORE the action executes, so we override OnActionExecuting:
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //The ActionParameters collection contains all of the parameters being passed to the action that this attribute decorates, so it occurs after the model binding has completed.
            var reportID = Convert.ToInt32(filterContext.ActionParameters["id"]);
            var report = ReportsManager.GetByID(reportID);
            int userID = 0;
            bool hasID = int.TryParse(filterContext.HttpContext.Session["CurrentUserID"].ToString(), out userID);
            if (!hasID)
            {
                //What goes here?
                //If they don't have a valid ID, we want to redirect back to Home/Index with a flash message, but we cannot call RedirectToAction from an Action Filter. Instead, we set the Result of the ActionExecutingContext to a new RedirectToRouteResult, like so:
                filterContext.Controller.TempData["FlashMessage"] = "Please select a valid User to access their reports.";
                //Change the Result to point back to Home/Index
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
                
            }
            else //We have selected a valid user
            {   
                //There's still one more scenario we need to handle: what if the user that's trying to access this report isn't the person that created it? In this scenario, just like the invalid-user-ID one, we want to redirect to Home/Index with a flash message.
                if (report.UserID != userID)
                {
                    filterContext.Controller.TempData["FlashMessage"] = "You cannot view Reports you have not created.";
                    //Change the Result to point back to Home/Index
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}