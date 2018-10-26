using DAL.Entities;
using DAL.Interfaces;
using DAL.EF;

namespace DAL.Repositories
{
    public class InventoryResultRepository : DataAccessRepository<InventoryResult>, IRepository<InventoryResult>
    {
        public InventoryResultRepository(ApplicationContext context) : base(context) { }
    }
}
