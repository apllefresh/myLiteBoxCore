using AutoMapper;
using Products.DAL.EF;
using Products.DAL.Contract.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Products.DAL.Repositories
{
    public abstract class DataAccessRepository<T> : IDataAccessRepository<T> where T : class, new()
    {
        private DataAccessContext _context;
        private readonly IMapper _mapper;
        private DbSet<T> _dbSet;

        protected DataAccessRepository(DataAccessContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context;
            context.Database.OpenConnection();
            _dbSet = context.Set<T>();
        }

        public virtual async Task<IReadOnlyCollection<T>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<T> Get(int id)
        {
            return await _dbSet.FindAsync(id).ConfigureAwait(false) as T;
        }

        public virtual async Task<IReadOnlyCollection<T>> Find(Func<T, Boolean> predicate)
        {
            var result = _dbSet.Where(predicate).ToList();
            return await result.ToAsyncEnumerable().ToList().ConfigureAwait(false);
        }

        public virtual async Task Create(T item)
        {
            await _dbSet.AddAsync(item).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        public virtual async Task Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        public virtual async Task Delete(int id)
        {
            T item = await Get(id);
            _dbSet.Remove(item);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task<IReadOnlyCollection<T>> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            return await Include(includeProperties).ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<IReadOnlyCollection<T>> GetWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = Include(includeProperties).Where(predicate);
            return await query.ToAsyncEnumerable().ToList().ConfigureAwait(false);
        }

        private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
