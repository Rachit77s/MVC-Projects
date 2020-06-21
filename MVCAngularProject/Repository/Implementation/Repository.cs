using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext db { get; set; }
        //public Repository(DbContext _db)
        //{
        //    db = _db;
        //}
        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public void DeleteById(object Id)
        {
            var entity = db.Set<TEntity>().Find(Id);
            if (entity != null)
                db.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
           return db.Set<TEntity>().ToList();
        }

        public TEntity GetById(object Id)
        {
            return db.Set<TEntity>().Find(Id);
        }

        public void Update(TEntity entity)
        {
            db.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}
