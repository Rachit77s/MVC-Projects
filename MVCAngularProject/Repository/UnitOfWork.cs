using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore;
using DomainModels.Entities;
using Repository.Abstraction;
using Repository.Implementation;

namespace Repository
{
    //The IUnitOfWork Design Pattern is used to perform DB operation on more than one entity in one go, so that if there is any issue while updating or saving the record then the entire databse transaction can be rolled back.
    //All the DB operation involving more than one repository would be done in a single transaction scope

    //UnitOfWork will contain all the repository that we are using in our code
    public class UnitOfWork : IUnitOfWork
    {
        DatabaseContext db;
        public UnitOfWork()
        {
            db = new DatabaseContext();
        }
        private IAuthenticateRepository _AuthenticateRepository;
        public IAuthenticateRepository AuthenticateRepository
        {
            get
            {
                //Call AuthenticateRepository class to initialise IAuthenticateRepository reference
                if (_AuthenticateRepository == null)
                    //Call the Constructor to initialise the class
                    _AuthenticateRepository = new AuthenticateRepository(db);
                return _AuthenticateRepository;
            }
        }
        
        private IRepository<Category> _CategoryRepository;
        public IRepository<Category> CategoryRepository
        {
            get
            {
                if (_CategoryRepository == null)
                    _CategoryRepository = new Repository<Category>(db);
                return _CategoryRepository;
            }
        }

        private IRepository<Product> _ProductRepository;
        public IRepository<Product> ProductRepository
        {
            get
            {
                if (_ProductRepository == null)
                    _ProductRepository = new Repository<Product>(db);
                return _ProductRepository;
            }
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
