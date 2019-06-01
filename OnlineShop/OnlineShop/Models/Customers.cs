using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Customers
    {
        public int CustomerId { get; set; }

       // [Required  ("FirstName")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateofBirth { get; set; }

        public string Gender { get; set; }

        public string IsActive { get; set; }

    }
}