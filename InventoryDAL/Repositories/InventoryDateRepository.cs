using InventoryDAL.Entities;
using InventoryDAL.Interfaces;
using InventoryDAL.EF;

namespace InventoryDAL.Repositories
{
    public class InventoryDateRepository : DataAccessRepository<InventoryDate>, IRepository<InventoryDate>
    {
        private ApplicationContext _context;
        public InventoryDateRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
