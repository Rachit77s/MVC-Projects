using DamcoEvaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamcoEvaluation.Repository
{
    public interface ISupplierRate : IDisposable
    {
        IEnumerable<SupplierRateModel> GetSupplierRate();

        IEnumerable<SupplierRateModel> GetSupplierOverlap(int id = 0);
    }
}
