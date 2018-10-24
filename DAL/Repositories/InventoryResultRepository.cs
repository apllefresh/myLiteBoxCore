using DAL.Entities;
using DAL.Interfaces;
using DAL.EF;

namespace DAL.Repositories
{
    public class InventoryResultRepository : DataAccessRepository<InventoryResult>, IRepository<InventoryResult>
    {
        private ApplicationContext db;

        public InventoryResultRepository(ApplicationContext context) : base(context) { }
    }
}
