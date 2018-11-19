﻿using Products.DAL.Contract.Models;

namespace Products.DAL.Contract.Interfaces
{
    public interface IProductRepository : IDataAccessRepository<Product>
    {
    }
}
