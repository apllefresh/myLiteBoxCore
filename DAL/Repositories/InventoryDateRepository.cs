using DAL.Entities;
using DAL.Interfaces;
using DAL.EF;

namespace DAL.Repositories
{
    public class InventoryDateRepository : DataAccessRepository<InventoryDate>, IRepository<InventoryDate>
    {
        public InventoryDateRepository(ApplicationContext context) : base(context) { }
    }
}
