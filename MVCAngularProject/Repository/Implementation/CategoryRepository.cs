using ApplicationCore;
using DomainModels.Entities;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }

        public CategoryRepository(DbContext db)
        {
            this.db = db;
        }

    }
}
