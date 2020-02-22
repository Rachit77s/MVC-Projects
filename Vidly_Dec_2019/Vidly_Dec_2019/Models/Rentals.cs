using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_Dec_2019.Models
{
    public class Rentals
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movy Movie { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturn { get; set; }
    }
}