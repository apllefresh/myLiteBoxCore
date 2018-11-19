﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryDAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<IReadOnlyCollection<T>> Find(Func<T, Boolean> predicate);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
    }
}