using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DamcoEvaluation.Models
{
    public class SupplierRateModel
    {
        public int Id { get; set; }

        public int SupplierNumber { get; set; }

        public int Rate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? EndDate { get; set; }

        public SupplierModel SupplierModel { get; set; }
    }
}
