using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Dec_2019.Models;
using System.Data.Entity;
using Vidly_Dec_2019.ViewModels;

namespace Vidly_Dec_2019.Controllers
{
    public class CustomersController : Controller
    {

        private VidlyEntities _context;

        public CustomersController()
        {
            _context = new VidlyEntities();      
        }

        //Disposing the constructor 
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();    
        }

        // GET: Customers
        public ActionResult Index()
        {
            //var customers = GetCustomers();
            // var movies = _context.Movies.Include(m => m.Genre).ToList();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
               return View(customers);
        }

        //Create a New customer 
        public ActionResult New()
        {
            var memberShipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerViewModel
            {
                Customer = new Customer(), //Here initialised customer with its default value because when we are saving the form id was 0 hence form was not getting saved due to validation error that ID field is required.
                MembershipTypes = memberShipTypes
            };
            return View("Create",viewModel);
        }


        //[Bind(Exclude = "Id")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save( Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("Create", viewModel);
            }

            if(customer.Id==0)
            _context.Customers.Add(customer);
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDB.Name = customer.Name;
                customerInDB.BirthDate = customer.BirthDate;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                
                //TryValidateModel(customerInDB); 
            }
            _context.SaveChanges(); 
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Details(int id)
        {
            //var customers = _context.Customers.SingleOrDefault(c => c.Id == id);

            var customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customers == null)
                return HttpNotFound();

            return View(customers);
        }



       // [HttpPost]
       //Edit a form
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("Create", viewModel);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
    }
}