using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            List<Customer> customers = GetCustomers();
            return View(customers);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var  customers = GetCustomers().SingleOrDefault(x => x.Id == id);
            if (customers == null)
                return Content("No customer matching the search result was found");

            return View(customers);
        }

        private List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer { Id = 1 , Name = "Jon Snow"},
                new Customer { Id = 2 , Name = "Daenaerys"}
            };

            return customers;
        }
    }
}