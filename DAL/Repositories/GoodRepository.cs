using DAL.Entities;
using DAL.Interfaces;
using DAL.EF;

using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class GoodRepository : DataAccessRepository<Good>, IRepository<Good>
    {
        private ApplicationContext db;

        public GoodRepository(ApplicationContext context) : base(context) { }

    }
}
