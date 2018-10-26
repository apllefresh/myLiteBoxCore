using DAL.Entities;
using DAL.Interfaces;
using DAL.EF;

namespace DAL.Repositories
{
    public class InventoryHeadRepository : DataAccessRepository<InventoryHead>, IRepository<InventoryHead>
    {
        public InventoryHeadRepository(ApplicationContext context) : base(context) { }
    }
}
