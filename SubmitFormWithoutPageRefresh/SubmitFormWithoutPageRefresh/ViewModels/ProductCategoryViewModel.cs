using SubmitFormWithoutPageRefresh.Controllers;
using SubmitFormWithoutPageRefresh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SubmitFormWithoutPageRefresh.ViewModels
{
    public class ProductCategoryViewModel
    {
        [Required]
        public IEnumerable<Category> Category { get; set; }
        [Required]
        public Products Products { get; set; }
    }
}