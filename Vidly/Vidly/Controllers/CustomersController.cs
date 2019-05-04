using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        public ActionResult OutputToAction()
        {
            return RedirectToRoute("MyCustomRoute");
        }

        public ActionResult CustomerForm()
        {
            // ...
            return RedirectToAction("Index");
        }
        // GET: Customers
        public ActionResult Index()
        {
            List<Customer> customers = GetCustomers();
            return View(customers);
        }


        public ActionResult New()
        {
            var membershipTypes = GetMembershipType();
            var viewModel = new CustomerFormViewModel
            {
                MembershipType = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            //if(!ModelState.IsValid)
            //{
            //    var membershipTypes = GetMembershipType();
            //    var viewModel = new CustomerFormViewModel
            //    {
            //        Customer = customer,
            //        MembershipType = membershipTypes
                    
            //    };
            //    return View("CustomerForm", viewModel);
            //}

            if (customer.Id == 0)
            {
                using (MyDbContext db = new MyDbContext())
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                }
            }//  add(customer); 
               
            else
            {
                using (MyDbContext db = new MyDbContext())
                {
                    var customerInDB = db.Customers.Single(c => c.Id == customer.Id);
                    customerInDB.Name = customer.Name;
                    customerInDB.Birthdate = customer.Birthdate;
                    customerInDB.MembershipType = customer.MembershipType;
                    customerInDB.MembershipTypeId = customer.MembershipTypeId;
                    customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                    db.SaveChanges();
                }
            
            }
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = GetCustomers().SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return Content("No customer matching the search result was found");

            var membershipTypes = GetMembershipType();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = membershipTypes

            };
            return View("CustomerForm",viewModel);
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
            using (MyDbContext db = new MyDbContext())
            {
                return db.Customers.ToList();
            }
            //List<Customer> customers = new List<Customer>
            //{
            //    new Customer { Id = 1 , Name = "Jon Snow"},
            //    new Customer { Id = 2 , Name = "Daenaerys"}
            //};

            //return customers;
        }

        private List<MembershipType> GetMembershipType()
        {
            using (MyDbContext db = new MyDbContext())
            {
                return db.MembershipTypeDB.ToList();
            }

            //List<MembershipType> membershipTypes = new List<MembershipType>
            //{
            //    new MembershipType { Id = 1 , Name = "Pay as you Go"},
            //    new MembershipType { Id = 2 , Name = "Quaterly"},
            //    new MembershipType { Id = 3 , Name = "Monthly"}
            //};

            //return membershipTypes;
        }
    }
}