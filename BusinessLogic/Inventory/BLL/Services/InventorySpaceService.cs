using AutoMapper;
using Inventory.DAL.Contract.Interfaces;
using DA = Inventory.DAL.Contract.Models;
using BL = Inventory.BLL.Contract.Models;
using BLI = Inventory.BLL.Contract.Interfaces;

namespace Inventory.BLL.Services
{
    public class InventorySpaceService : BusinessLogicService<BL.InventorySpace, DA.InventorySpace>, BLI.IInventorySpaceService
    {
        private IInventorySpaceRepository _repository;
        private IMapper _mapper;

        public InventorySpaceService(IInventorySpaceRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
