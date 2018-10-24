using DAL.Entities;
using DAL.Interfaces;
using DAL.EF;

namespace DAL.Repositories
{
    public class InventoryDateRepository : DataAccessRepository<InventoryDate>, IRepository<InventoryDate>
    {
        private ApplicationContext db;

        public InventoryDateRepository(ApplicationContext context) : base(context) { }
    }
}
