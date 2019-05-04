using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            List<Movie> movies = GetMovies();
            return View(movies);
            
        }

        public ActionResult MovieForm()
        {
            // ...
            return RedirectToAction("Save","Movies", FormMethod.Get);
        }

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Title = "Insert New Movie";
            using (MyDbContext db = new MyDbContext())
            {
                var GenreType = db.Genres.ToList();
                var viewModel = new MovieFormViewModel
                {
                    Genres = GenreType
                };
                return View("MovieForm", viewModel);
            }
            
        }

        [HttpPost]
        public ActionResult Save( Movie movie)
        {
            ViewBag.Title = "Insert New Movie";
            //if (ModelState.IsValid)
            //{
            using (MyDbContext db = new MyDbContext())
                {

                    if(!ModelState.IsValid)
                    {
                        var genreType = GetGenres();
                        var viewModel = new MovieFormViewModel
                        {
                            Movie = new Movie(),
                            Genres = genreType
                        };
                        return View("MovieForm", viewModel);
                    }
                    if (movie.Id == 0)
                    {
                        var GenreType = db.Genres.SingleOrDefault(x => x.Id == movie.GenreId);
                        movie.Genre = GenreType.Name.ToString();
                        db.Movies.Add(movie);
                        db.SaveChanges();

                    }
                    else
                    {   //Name , ReleaseDate, Genre, Number In Stock
                        var movieInDB = db.Movies.Single(c => c.Id == movie.Id);
                        movieInDB.Name = movie.Name;
                        movieInDB.DateAdded = movie.DateAdded;
                        var GenreType = db.Genres.SingleOrDefault(x => x.Id == movie.GenreId);
                        movieInDB.Genre = GenreType.Name;
                        movieInDB.GenreId = movie.GenreId;
                        movieInDB.NumberInStock = movie.NumberInStock;
                        db.SaveChanges();

                    }
                   
                }
            //}

            return RedirectToAction("Index", "Movies");
        }


        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit Movie";
            var movie = GetMovies().SingleOrDefault(x => x.Id == id);
            if (movie == null)
                return Content("No movie matching the search result was found");
            //Get all genres
            var genreType = GetGenres();
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = genreType
            };

            return View("MovieForm", viewModel);
        }
        // GET: Movies
        [HttpPost]
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            
            return Content( string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy) );
        }
       
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer {Name="Customer 1"},
                new Customer {Name="Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult ByReleaseDate(int year,int month )
        {
           
            return Content(year + "/" + month);
        }

        public ActionResult Details(int id)
        {
            var movies = GetMovies().SingleOrDefault(x => x.Id == id);
            if (movies == null)
                return Content("No movies matching the search result was found");

            return View(movies);
        }

        private List<Movie> GetMovies()
        {
            using (MyDbContext db = new MyDbContext())
            {
                return db.Movies.ToList();
            }

            //List<Movie> movies = new List<Movie>
            //{
            //    new Movie { Id = 1 , Name = "GOT"},
            //    new Movie { Id = 2 , Name = "BB"}
            //};

            //return movies;
        }

        private List<Genre> GetGenres()
        {
            using (MyDbContext db = new MyDbContext())
            {
                return db.Genres.ToList();
            }
        }



        }
}