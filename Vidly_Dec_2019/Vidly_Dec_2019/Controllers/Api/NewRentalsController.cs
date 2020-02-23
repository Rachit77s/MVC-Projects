using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Vidly_Dec_2019.Models;

namespace Vidly_Dec_2019.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private VidlyEntities _context;
        private VidlyEntitiesMovies _contextMovie;

        //[System.Web.Http.HttpPost]
        //public ActionResult CreateNewRentals(Rentals rental) 
        //{
        //    var customer = _context.Customers.Single(c=> c.Id == rental.Customer.Id);

        //    var movies = _contextMovie.Movies.Single(c => c.Id == rental.Movie.Id);

        //    var rentals = new Rentals
        //    {
        //        Customer = customer,
        //        Movie = movies,
        //        DateRented = DateTime.Now
        //    };

        //    return View(movies);
        //}

  
    }
}
