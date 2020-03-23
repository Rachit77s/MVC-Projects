using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InfrrdTest.Models
{
    public class FormModel
    {
        public int DetailID { get; set; }

        [DisplayName("Category")]
        [Required]
        public int CategoryID { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public int Amount { get; set; }

        [NotMapped]
        public List<CategoryModel> CategoryCollection { get; set; }

        [NotMapped]
        public string CategoryNameField { get; set; }
    }
}