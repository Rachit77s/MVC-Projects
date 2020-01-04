using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Dec_2019.Models;

namespace Vidly_Dec_2019.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}