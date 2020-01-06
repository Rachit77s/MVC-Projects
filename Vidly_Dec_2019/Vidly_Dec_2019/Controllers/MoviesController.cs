using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Dec_2019.Models;
using Vidly_Dec_2019.ViewModels;
using System.Data.Entity;

namespace Vidly_Dec_2019.Controllers
{
    public class MoviesController : Controller
    {
        private VidlyEntitiesMovies _context;

        public MoviesController()
        {
            _context = new VidlyEntitiesMovies();
        }

        public ViewResult Index()
        {
            //var movies = GetMovies();

             var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }


        [HttpGet]
        public ActionResult Create()
        {
            
            var genreList = _context.Genres.ToList();
            var movieViewModel = new MovieViewModel
            {
                Movie = new Movy(),
                Genres = genreList
            };
            return View("Create" , movieViewModel);        

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Movy movie)
        {
           // bool status = false;

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("Create", viewModel);
            }
                          
                    //Edit the Movie
             if (movie.Id > 0)
             {
                 //var v = _context.Movies.Where(m => m.Id == movie.Id).FirstOrDefault();
                 var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                     if (movieInDb != null)
                     {
                 
                         movieInDb.Name = movie.Name;
                         movieInDb.GenreId = movie.GenreId;
                         movieInDb.NumberInStock = movie.NumberInStock;
                         movieInDb.ReleaseDate = movie.ReleaseDate;
                      }
             }
             else
             {
             //Save
                 _context.Movies.Add(movie);
             }

              _context.SaveChanges();
               //status = true;               
            
            return RedirectToAction("Index", "Movies");
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var movieViewModel = new MovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("Create", movieViewModel);
        }

            public ActionResult Details(int id)
        {
            //var customers = GetMovies().SingleOrDefault(m => m.Id == id);


            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
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