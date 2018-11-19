using AutoMapper;
using Inventory.DAL.Contract.Interfaces;
using DA = Inventory.DAL.Contract.Models;
using BL = Inventory.BLL.Contract.Models;
using BLI = Inventory.BLL.Contract.Interfaces;

namespace Inventory.BLL.Services
{
    public class InventoryResultService : BusinessLogicService<BL.InventoryResult, DA.InventoryResult>, BLI.IInventoryResultService
    {
        private IInventoryResultRepository _repository;
        private IMapper _mapper;

        public InventoryResultService(IInventoryResultRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
