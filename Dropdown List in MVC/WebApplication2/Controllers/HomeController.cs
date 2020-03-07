using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var list = new List<string>() { "India", "China", "USA", "Korea", "Japan" };
            ViewBag.list = list;
            return View();

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod()
        {
            List<SelectListItem> customers = new List<SelectListItem>();
            TestEntities entities = new TestEntities();
            for (int i = 0; i < entities.Employees.Count(); i++)
            {
                customers.Add(new SelectListItem
                {
                    Value = entities.Employees.ToList()[i].EmployeeID.ToString(),
                    Text = entities.Employees.ToList()[i].FirstName
                });
            }

            return Json(customers);
        }


        public ActionResult PopulateCustomer()
        {
            var list = new List<string>() {"India", "China", "USA", "Korea", "Japan"};
            ViewBag.list = list;
            return View();
        }


    }
}