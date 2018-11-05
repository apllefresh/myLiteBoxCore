using B = BLL.Entities;
using BI = BLL.Interfaces;
using D = DAL.Entities;
using DAL.Interfaces;
using AutoMapper;
using DAL.Repositories;

namespace BLL.Services
{
    public class InventoryService : BLLService<B.InventoryDate, D.InventoryDate>, BI.IInventoryService
    {
        private IRepository<D.InventoryDate> _repository;
        private IMapper _mapper;

        public InventoryService(InventoryDateRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
