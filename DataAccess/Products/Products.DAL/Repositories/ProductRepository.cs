using AutoMapper;
using Products.DAL.Contract.Interfaces;
using Products.DAL.EF;
using Products.DAL.Contract.Models;

namespace Products.DAL.Repositories
{
    public class ProductRepository : DataAccessRepository<Product>, IProductRepository
    {
        private DataAccessContext _context;
        private IMapper _mapper;

        public ProductRepository(DataAccessContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
