using DomainModels.Entities;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    //Rachit
    //The IUnitOfWork Design Pattern is used to perform DB operation on more than one entity in one go, so that if there is any issue while updating or saving the record then the entire databse transaction can be rolled back.
    //All the DB operation involving more than one repository would be done in a single transaction scope.

    //UnitOfWork will contain all the repository that we are using in our code
    public interface IUnitOfWork
    {
        IAuthenticateRepository AuthenticateRepository { get; }
        IRepository<Category> CategoryRepository { get; }
        IRepository<Product> ProductRepository { get; }

        int SaveChanges();
    }
}
