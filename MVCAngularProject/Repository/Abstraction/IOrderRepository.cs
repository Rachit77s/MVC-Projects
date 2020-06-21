using DomainModels.Entities;
using DomainModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstraction
{
    public interface IOrderRepository : IRepository<Order>
    {
        int SaveCart(Cart model);
        void PlaceOrder(TransactionModel model);
    }
}
