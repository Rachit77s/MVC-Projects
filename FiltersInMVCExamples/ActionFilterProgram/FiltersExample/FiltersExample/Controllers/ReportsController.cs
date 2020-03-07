using FiltersExample.Attributes;
using FiltersExample.DataAccess.Managers;
using FiltersExample.ViewModels.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersExample.Controllers
{
    public class ReportsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ReportsIndexVM model = new ReportsIndexVM();
           
            model.Reports = ReportsManager.GetAll();
            return View(model);
        }

        [HttpGet]
        [CanEditReport]
        public ActionResult View(int id)
        {
            var report = ReportsManager.GetByID(id);
            
            return View(report);
        }

        public void ExampleMethod(int required, string optionalstr = "default string", int optionalint = 10, int optionalint2 = 40)
        {
            Console.WriteLine("{0}: {1}, {2}, and {3}.", required, optionalstr, optionalint, optionalint2);
        }


       
    }
}
