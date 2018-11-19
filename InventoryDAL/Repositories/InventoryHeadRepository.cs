using InventoryDAL.Entities;
using InventoryDAL.Interfaces;
using InventoryDAL.EF;

namespace InventoryDAL.Repositories
{
    public class InventoryHeadRepository : DataAccessRepository<InventoryHead>, IRepository<InventoryHead>
    {
        private ApplicationContext _context;
        public InventoryHeadRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
