using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inventory.DAL.Contract.Interfaces
{
    public interface IDataAccessRepository<T> where T : class
    {
        Task<IReadOnlyCollection<T>> GetAll();
        Task<T> Get(int id);
        Task<IReadOnlyCollection<T>> Find(Func<T, Boolean> predicate);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);

        Task<IReadOnlyCollection<T>> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
        Task<IReadOnlyCollection<T>> GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);
    }
}
