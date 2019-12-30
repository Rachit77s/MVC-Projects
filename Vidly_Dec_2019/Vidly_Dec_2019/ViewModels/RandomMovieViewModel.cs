using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Dec_2019.Models;

namespace Vidly_Dec_2019.ViewModels
{
    //we are showing list of customers based on the movie so we have taken 2 Model classes and appended here below
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}