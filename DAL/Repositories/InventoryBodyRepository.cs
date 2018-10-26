using DAL.Entities;
using DAL.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class InventoryBodyRepository : DataAccessRepository<InventoryBody>,IRepository<InventoryBody>
    {
        public InventoryBodyRepository(ApplicationContext context):base(context){ }
    }
}
