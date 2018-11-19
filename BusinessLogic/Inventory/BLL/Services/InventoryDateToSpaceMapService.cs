using AutoMapper;
using Inventory.DAL.Contract.Interfaces;
using DA = Inventory.DAL.Contract.Models;
using BL = Inventory.BLL.Contract.Models;
using BLI = Inventory.BLL.Contract.Interfaces;

namespace Inventory.BLL.Services
{
    public class InventoryDateToSpaceMapService : BusinessLogicService<BL.InventoryDateToSpaceMap, DA.InventoryDateToSpaceMap>, BLI.IInventoryDateToSpaceMapService
    {
        private IInventoryDateToSpaceMapRepository _repository;
        private IMapper _mapper;

        public InventoryDateToSpaceMapService(IInventoryDateToSpaceMapRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
