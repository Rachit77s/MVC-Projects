using API.Repository;
using DamcoEvaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamcoEvaluation.Repository
{
    public class MockSupplierRateRepository : IDisposable, ISupplierRate
    {
        private readonly List<SupplierRateModel> _supplierRateModel;

        public MockSupplierRateRepository()
        {
            _supplierRateModel = new List<SupplierRateModel>()
            {
                new SupplierRateModel() { Id = 1, SupplierNumber = 1, Rate = 10, StartDate = Convert.ToDateTime("1 Jan 2015"), EndDate = Convert.ToDateTime("31 Mar 2015") },
                new SupplierRateModel() { Id = 2, SupplierNumber = 1, Rate = 20, StartDate = Convert.ToDateTime("1 Apr 2015"), EndDate = Convert.ToDateTime("1 May 2015") },
                new SupplierRateModel() { Id = 3, SupplierNumber = 1, Rate = 10, StartDate = Convert.ToDateTime("30 May 2015"), EndDate = Convert.ToDateTime("25 July 2015") },
                new SupplierRateModel() { Id = 4, SupplierNumber = 1, Rate = 25, StartDate = Convert.ToDateTime("1 Oct 2015"), EndDate = null  },
                new SupplierRateModel() { Id = 5, SupplierNumber = 2, Rate = 100, StartDate = Convert.ToDateTime("1 Nov 2016"), EndDate = null  },
                new SupplierRateModel() { Id = 6, SupplierNumber = 3, Rate = 30, StartDate = Convert.ToDateTime("1 Dec 2016"), EndDate = Convert.ToDateTime("1 Jan 2017") },
                new SupplierRateModel() { Id = 7, SupplierNumber = 3, Rate = 30, StartDate = Convert.ToDateTime("2 Jan 2017"), EndDate = null  }
            };
        }


        public void Dispose()
        {

        }


        public IEnumerable<SupplierRateModel> GetSupplierRate()
        {
            return this._supplierRateModel;
        }


        public IEnumerable<SupplierRateModel> GetSupplierOverlap(int id = 0)
        {
            IEnumerable<SupplierRateModel> result;

            if (id > 0)
            {
                result = _supplierRateModel
                         .Where(x => x.SupplierNumber == id)
                         .GroupBy(item => item.Rate)
                         .Select(grouping => grouping.FirstOrDefault())
                         .OrderByDescending(item => item.Rate)
                         .ToList();
            }
            else
            {
                result = _supplierRateModel.GroupBy(item => item.Rate)
                         .Select(grouping => grouping.FirstOrDefault())
                         .OrderByDescending(item => item.Rate)
                         .ToList();
            }

            return result;
        }
    }
}
