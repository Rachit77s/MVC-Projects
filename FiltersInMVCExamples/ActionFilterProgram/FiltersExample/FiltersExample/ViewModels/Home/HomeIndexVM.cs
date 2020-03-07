
using FiltersExample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FiltersExample.ViewModels.Home
{
    public class HomeIndexVM
    {
        public List<User> Users { get; set; }

        [DisplayName("Select a User:")]
        public int SelectedUser { get; set; }
    }
}