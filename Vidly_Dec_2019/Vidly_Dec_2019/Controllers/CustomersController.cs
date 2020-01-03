﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Dec_2019.Models;

namespace Vidly_Dec_2019.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();      
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

            var customers = _context.Customers.ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.Id == id);

            //var customers1 = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customers == null)
                return HttpNotFound();

            return View(customers);
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