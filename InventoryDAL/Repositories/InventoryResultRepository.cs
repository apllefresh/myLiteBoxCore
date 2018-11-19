using InventoryDAL.Entities;
using InventoryDAL.Interfaces;
using InventoryDAL.EF;

namespace InventoryDAL.Repositories
{
    public class InventoryResultRepository : DataAccessRepository<InventoryResult>, IRepository<InventoryResult>
    {
        private ApplicationContext _context;
        public InventoryResultRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
