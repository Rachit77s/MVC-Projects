using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Dec_2019.Models;

namespace Vidly_Dec_2019.ViewModels
{
    public class MovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movy Movie { get; set; }
        
        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }

    }
}