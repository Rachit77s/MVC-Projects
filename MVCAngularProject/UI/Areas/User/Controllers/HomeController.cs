using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.User.Controllers
{
    public class HomeController : BaseController
    {
        // GET: User/Home
        public ActionResult Index()
        {
            int UserId = CurrentUser.UserId;
            return View();
        }
    }
}