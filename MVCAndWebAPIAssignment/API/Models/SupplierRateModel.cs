using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamcoEvaluation.Models
{
    public class SupplierRateModel
    {
        public int Id { get; set; }

        public int SupplierNumber { get; set; }

        public int Rate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public SupplierModel SupplierModel { get; set; }
    }
}
