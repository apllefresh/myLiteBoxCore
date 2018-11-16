using InventoryDAL.Entities;
using InventoryDAL.Interfaces;
using InventoryDAL.EF;

namespace InventoryDAL.Repositories
{
    class GoodGroupRepository : DataAccessRepository<GoodGroup>, IRepository<GoodGroup>
    {
        private ApplicationContext _context;
        public GoodGroupRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}