using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public abstract class DataAccessRepository<T> : IRepository<T> where T : class, new()
    {
        private ApplicationContext db;
        private DbSet<T> _dbSet;

        public DataAccessRepository(ApplicationContext context)
        {
            this.db = context;
            context.Database.OpenConnection();
            _dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<T> Get(int id)
        {
            return await _dbSet.FindAsync(id).ConfigureAwait(false) as T;
        }


        //public virtual IEnumerable<T> Find(Func<T, Boolean> predicate)
        //{
        //    return _dbSet.Where(predicate);
        //}

        public virtual async Task<IEnumerable<T>> Find(Func<T, Boolean> predicate)
        {
            var result = _dbSet.Where(predicate);

            return await result.AsQueryable<T>().ToListAsync().ConfigureAwait(false);// ToAsyncEnumerable<IEnumerable<T>>();
            
        }

        public virtual async Task Create(T item)
        {
            await _dbSet.AddAsync(item).ConfigureAwait(false);
            await db.SaveChangesAsync().ConfigureAwait(false);
        }
        public virtual async Task Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync().ConfigureAwait(false); 
        }
        public virtual async Task Delete(int id)
        {
             T item = await Get(id);
            _dbSet.Remove(item);
            await db.SaveChangesAsync().ConfigureAwait(false);
        }

    }
}
