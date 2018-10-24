using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DAL.Repositories
{
    public abstract class DataAccessRepository<T> : IRepository<T> where T : class, new()
    {
        private ApplicationContext db;
        private DbSet<T> _dbSet;

        public DataAccessRepository(ApplicationContext context)
        {
            this.db = context;
            _dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public virtual T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> Find(Func<T, Boolean> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        //void Create(T item);
        //void Update(T item);
        //void Delete(int id);

        public virtual void Create(T item)
        {
            _dbSet.Add(item);
            db.SaveChanges();
        }
        public virtual void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
        public virtual void Delete(int id)
        {
             T item = Get(id);
            _dbSet.Remove(item);
            db.SaveChanges();
        }

    }
}
