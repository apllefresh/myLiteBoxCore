using AutoMapper;
using Inventory.DAL.Models;
using Inventory.DAL.Contract.Interfaces;
using Inventory.DAL.EF;

namespace Inventory.DAL.Repositories
{
    public class InventoryBodyRepository : DataAccessRepository<InventoryBody>
    {
        private DataAccessContext _context;
        private IMapper _mapper;

        public InventoryBodyRepository(DataAccessContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
