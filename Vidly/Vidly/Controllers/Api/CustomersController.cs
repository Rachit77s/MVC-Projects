using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private MyDbContext myDbContextApi;

        public CustomersController()
        {
            myDbContextApi = new MyDbContext();
        }

        //GET api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return myDbContextApi.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        //GET api/customers/1
        public CustomerDto GetCustomer(int id)
        {
            var customer = myDbContextApi.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                //    return Content("No customer matching the search result was found");
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Customer,CustomerDto>(customer);
        }

        //POST /api/customer
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            myDbContextApi.Customers.Add(customer);
            customerDto.Id = customer.Id;
            return customerDto;
        }

        //PUT /api/customers/1
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = myDbContextApi.Customers.Single(c => c.Id == customerDto.Id);

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //customerInDB.Name = customer.Name;
            //customerInDB.Birthdate = customer.Birthdate;
            //customerInDB.MembershipType = customer.MembershipType;
            //customerInDB.MembershipTypeId = customer.MembershipTypeId;
            //customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            //myDbContextApi.SaveChanges();

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDB);
            myDbContextApi.SaveChanges();
        }


        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDB = myDbContextApi.Customers.Single(c => c.Id == id);

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            myDbContextApi.Customers.Remove(customerInDB);
            myDbContextApi.SaveChanges();
        }


    }
}
