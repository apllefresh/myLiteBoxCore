using DAL.Entities;
using DAL.Interfaces;
using DAL.EF;

namespace DAL.Repositories
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
