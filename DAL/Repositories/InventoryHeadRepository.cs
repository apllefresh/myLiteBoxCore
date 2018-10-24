using DAL.Entities;
using DAL.Interfaces;
using DAL.EF;

namespace DAL.Repositories
{
    public class InventoryHeadRepository : DataAccessRepository<InventoryHead>, IRepository<InventoryHead>
    {
        private ApplicationContext db;

        public InventoryHeadRepository(ApplicationContext context) : base(context) { }
    }
}
