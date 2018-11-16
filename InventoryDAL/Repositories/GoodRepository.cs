using InventoryDAL.Entities;
using InventoryDAL.Interfaces;
using InventoryDAL.EF;

using System;
using System.Collections.Generic;

namespace InventoryDAL.Repositories
{
    public class GoodRepository : DataAccessRepository<Good>, IRepository<Good>
    {
        private ApplicationContext _context;
        public GoodRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

    }
}
