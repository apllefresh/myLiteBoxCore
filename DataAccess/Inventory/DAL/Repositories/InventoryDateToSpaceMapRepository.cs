using AutoMapper;
using Inventory.DAL.Contract.Interfaces;
using Inventory.DAL.EF;
using Inventory.DAL.Contract.Models;

namespace Inventory.DAL.Repositories
{
    public class InventoryDateToSpaceMapRepository : DataAccessRepository<InventoryDateToSpaceMap>, IInventoryDateToSpaceMapRepository
    {
        private DataAccessContext _context;
        private IMapper _mapper;

        public InventoryDateToSpaceMapRepository(DataAccessContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
