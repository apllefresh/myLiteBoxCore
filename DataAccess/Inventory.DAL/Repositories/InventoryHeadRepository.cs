using Inventory.DAL.Models;
using Inventory.DAL.Contract.Interfaces;
using Inventory.DAL.EF;
using AutoMapper;

namespace Inventory.DAL.Repositories
{
    public class InventoryHeadRepository : DataAccessRepository<InventoryHead>
    {
        private DataAccessContext _context;
        private IMapper _mapper;
        public InventoryHeadRepository(DataAccessContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
