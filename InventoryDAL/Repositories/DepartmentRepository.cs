using InventoryDAL.Entities;
using InventoryDAL.Interfaces;
using InventoryDAL.EF;

namespace InventoryDAL.Repositories
{
    class DepartmentRepository : DataAccessRepository<Department>, IRepository<Department>
    {
        private ApplicationContext _context;
        public DepartmentRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
