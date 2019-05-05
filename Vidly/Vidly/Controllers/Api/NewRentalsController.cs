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
    public class NewRentalsController : ApiController
    {
        private MyDbContext myDbContextApi;
        public NewRentalsController()
        {
            myDbContextApi = new MyDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalsDto newRental)
        {
            var customer = myDbContextApi.Customers.Single(c => c.Id == newRental.CustomerId);
            var moviename = myDbContextApi.Movies.Where(
                                m => newRental.MovieIds.Contains(m.Id));

            foreach(var movie in moviename)
            {
                if(movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rentals
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                myDbContextApi.Rentals.Add(rental);
               
            }

            myDbContextApi.SaveChanges();

            return Ok();
        }

        // static void Main(string[] args)
        //{

        //}
    }
}
