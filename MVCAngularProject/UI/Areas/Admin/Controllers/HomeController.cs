using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork _uow) : base(_uow)
        {
                
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}