using API.Models;
using DamcoEvaluation.Models;
using DamcoEvaluation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [LogApiCustomExceptionFilter]
    public class SupplierController : ApiController
    {
        // GET api/values
        public IEnumerable<SupplierRateModel> Get()
        {              
            using (ISupplierRate mockSupplier = new MockSupplierRateRepository())
            {               
                var empData = mockSupplier.GetSupplierRate();
                return empData;
            }                        
        }

        // GET api/values/5
        public IEnumerable<SupplierRateModel> Get(int id)
        {
            using (ISupplierRate mockSupplier = new MockSupplierRateRepository())
            {
                var empData = mockSupplier.GetSupplierOverlap(id);
                return empData;
            }           
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        
    }
}
