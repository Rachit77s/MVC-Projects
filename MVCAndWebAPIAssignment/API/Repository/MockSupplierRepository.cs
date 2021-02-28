using DamcoEvaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Repository
{
    public class MockSupplierRepository : IDisposable
    {
        private readonly List<SupplierModel> _supplierModel;

        public MockSupplierRepository()
        {
            _supplierModel = new List<SupplierModel>()
            {
                new SupplierModel() { Id = 1, Number = 1, Name = "EasyFarm"  },
                new SupplierModel() { Id = 2, Number = 2, Name = "PureVeggies"  },
                //new SupplierModel() { Id = 3, Number = 1, Name = ""  },
                //new SupplierModel() { Id = 3, Number = 1, Name = ""  }
            };
        }

        public IEnumerable<SupplierModel> GetSupplier()
        {
            return _supplierModel;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}