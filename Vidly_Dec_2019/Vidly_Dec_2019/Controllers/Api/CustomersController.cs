using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_Dec_2019.Models;

namespace Vidly_Dec_2019.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private VidlyEntities _context;

        public CustomersController()
        {
            _context = new VidlyEntities();
        }

        //GET
        //api/customers
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            //System.Diagnostics.Debugger.Break();
            return _context
                .Customers
                //.Include(m => m.MembershipType)
                .ToList();
        }

        //GET
        //api/customers/1
        [HttpGet]
        public IHttpActionResult GetCustomers(int id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                // throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            //return customer;
            return Ok(customer);
        }


        //POST
        //api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            _context.Customers.Add(customer);
            _context.SaveChanges();

            //return customer;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customer);
        }


        //PUT
        //api/customers/1
        [HttpPut]
        public Customer UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.Name = customer.Name;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            _context.SaveChanges();

            return customer;
        }


        //DELETE
        //api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }


    }
}