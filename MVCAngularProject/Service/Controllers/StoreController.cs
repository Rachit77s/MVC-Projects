using DomainModels.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Service.Controllers
{
    [EnableCors("*","*","*")]
    public class StoreController : ApiController
    {
        IUnitOfWork uow;
        public StoreController()
        {
            uow = new UnitOfWork();
        }
        public IEnumerable<Product> GetProducts()
        {
            return uow.ProductRepository.GetAll();
        }

        //[CustomAuthorizeFilter(Roles = "User")]
        //public int SaveCart(Cart cart)
        //{
        //    return uow.OrderRepository.SaveCart(cart);
        //}
    }
}
