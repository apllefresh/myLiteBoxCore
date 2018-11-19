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
    public class InventoryHeadService : BusinessLogicService<BL.InventoryHead, DA.InventoryHead>, BLI.IInventoryHeadService
    {
        private IInventoryHeadRepository _repository;
        private IMapper _mapper;

        public InventoryHeadService(IInventoryHeadRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IReadOnlyCollection<BL.InventoryHead>> GetAllItems(int inventoryDateId)
        {
            var items = await _repository.Find(t => t.InventoryDateId == inventoryDateId).ConfigureAwait(false);
            return items.Select(item => _mapper.Map<BL.InventoryHead>(item)).ToArray();
        }
    }
}
