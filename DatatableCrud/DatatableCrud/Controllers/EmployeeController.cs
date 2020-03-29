using DatatableCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatatableCrud.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (TestRachitEntities db = new TestRachitEntities())
            {
                List<Employee> empList = db.Employees.ToList();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpGet]
        public ActionResult AddorEdit(int id=0)
        {

            return View(new Employee());
        }

        [HttpPost]
        public ActionResult AddorEdit(Employee employee)
        {
            using (TestRachitEntities db = new TestRachitEntities())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return Json(new {success = true, message = "Saved successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}