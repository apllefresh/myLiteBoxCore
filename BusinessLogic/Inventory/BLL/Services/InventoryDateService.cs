using AutoMapper;
using Inventory.DAL.Contract.Interfaces;
using DA = Inventory.DAL.Contract.Models;
using BL = Inventory.BLL.Contract.Models;
using BLI = Inventory.BLL.Contract.Interfaces;

namespace Inventory.BLL.Services
{
    public class InventoryDateService : BusinessLogicService<BL.InventoryDate, DA.InventoryDate>, BLI.IInventoryDateService
    {
        private IInventoryDateRepository _repository;
        private IMapper _mapper;

        public InventoryDateService(IInventoryDateRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
