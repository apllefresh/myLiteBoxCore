using AutoMapper;
using Products.DAL.Contract.Interfaces;
using Products.DAL.EF;
using Products.DAL.Contract.Models;

namespace Products.DAL.Repositories
{
    public class DepartmentRepository : DataAccessRepository<Department>, IDepartmentRepository
    {
        private DataAccessContext _context;
        private IMapper _mapper;

        public DepartmentRepository(DataAccessContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
