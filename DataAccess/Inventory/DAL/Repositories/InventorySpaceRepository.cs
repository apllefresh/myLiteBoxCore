using AutoMapper;
using Inventory.DAL.Contract.Interfaces;
using Inventory.DAL.EF;
using Inventory.DAL.Contract.Models;

namespace Inventory.DAL.Repositories
{
    public class InventorySpaceRepository : DataAccessRepository<InventorySpace>, IInventorySpaceRepository
    {
        private DataAccessContext _context;
        private IMapper _mapper;

        public InventorySpaceRepository(DataAccessContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
