using AutoMapper;
using Inventory.DAL.Contract.Interfaces;
using DA = Inventory.DAL.Contract.Models;
using BL = Inventory.BLL.Contract.Models;
using BLI = Inventory.BLL.Contract.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.BLL.Services
{
    public class InventoryBodyService : BusinessLogicService<BL.InventoryBody, DA.InventoryBody>, BLI.IInventoryBodyService
    {
        private IInventoryBodyRepository _repository;
        private IMapper _mapper;

        public InventoryBodyService(IInventoryBodyRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IReadOnlyCollection<BL.InventoryBody>> GetAllItems(int inventoryBodyId)
        {
            var items = await _repository.Find(t => t.InventoryHeadId == inventoryBodyId).ConfigureAwait(false);
            return items.Select(item => _mapper.Map<BL.InventoryBody>(item)).ToArray();
        }
    }
}
