using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Dec_2019.Models;
using Vidly_Dec_2019.ViewModels;

namespace Vidly_Dec_2019.Controllers
{
    public class MoviesController : Controller
    {

        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var customers = GetMovies().SingleOrDefault(m => m.Id == id);
            if (customers == null)
                return HttpNotFound();

            return View(customers);
        }



        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }



        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };

            var customers = new List<Customer>
            {
                new Customer{ Name = "Customer1"},
                new Customer{ Name = "Customer2"},
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,              //2 Data Property of ViewModel Movie and Customers
                Customers = customers
            };

            return View(viewModel);
        }

        //Passing parameters in he query string
        //public ActionResult Indez(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}

            [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            //var movie = new Movie() { Name = "Shrek" };
            //return View(movie);
            return Content(year + "/" + month);
        }

    }
}