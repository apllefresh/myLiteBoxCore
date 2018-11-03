using DAL.Entities;
using DAL.Interfaces;
using DAL.EF;

namespace DAL.Repositories
{
    class GoodGroupRepository : DataAccessRepository<GoodGroup>, IRepository<GoodGroup>
    {
        public GoodGroupRepository(ApplicationContext context) : base(context) { }
    }
}