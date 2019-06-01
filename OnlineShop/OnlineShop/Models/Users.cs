using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Users
    {

        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string EmailId { get; set; }

        public int CustomerId { get; set; }

        public string IsActive { get; set; }

    }
}