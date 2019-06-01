using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels
{
    public class ProductCategoryViewModel
    {
        [Required]
        public IEnumerable<Category> Category { get; set; }
        [Required]
        public Products Products { get; set; }
    }
}