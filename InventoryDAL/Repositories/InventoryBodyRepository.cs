using InventoryDAL.Entities;
using InventoryDAL.Interfaces;
using InventoryDAL.EF;
using Microsoft.EntityFrameworkCore;

namespace InventoryDAL.Repositories
{
    public class InventoryBodyRepository : DataAccessRepository<InventoryBody>,IRepository<InventoryBody>
    {
        private ApplicationContext _context;

        public InventoryBodyRepository(ApplicationContext context) : base(context) 
        {
            _context = context;            
        }
    }
}
