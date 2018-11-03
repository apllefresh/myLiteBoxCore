using DAL.Entities;
using DAL.Interfaces;
using DAL.EF;

namespace DAL.Repositories
{
    class DepartmentRepository : DataAccessRepository<Department>, IRepository<Department>
    {
        public DepartmentRepository(ApplicationContext context) : base(context) { }
    }
}
