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
        private IInventoryHeadRepository _headRepository;
        private IInventorySpaceRepository _spaceRepository;
        private IMapper _mapper;

        public InventoryHeadService(IInventoryHeadRepository headRepository, IInventorySpaceRepository spaceRepository, IMapper mapper) : base(headRepository, mapper)
        {
            _headRepository = headRepository;
            _spaceRepository = spaceRepository;
            _mapper = mapper;
        }


        public async Task<IReadOnlyCollection<BL.InventoryHead>> GetAllItems(int inventoryDateId)
        {
            var heads = await _headRepository.Find(t => t.InventoryDateId == inventoryDateId).ConfigureAwait(false);
            var spaces = await _spaceRepository.GetAll().ConfigureAwait(false);

            var headsBLL = heads.Select(item => _mapper.Map<BL.InventoryHead>(item)).ToArray();
            var spacesBLL = spaces.Select(item => _mapper.Map<BL.InventorySpace>(item)).ToArray();

            foreach (var head in headsBLL)
            {
                head.InventorySpaceName = spacesBLL.Where(space => space.Id == head.InventorySpaceId).Select(space => space.Name).FirstOrDefault();
            }
            
            return headsBLL.ToArray(); 
           
        }
    }
}
