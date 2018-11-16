using B = BLL.Entities;
using BI = BLL.Interfaces;
using D = InventoryDAL.Entities;
using InventoryDAL.Interfaces;
using AutoMapper;
using InventoryDAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BLL.Services
{
    public class InventoryHeadService : BLLService<B.InventoryHead, D.InventoryHead>, BI.IInventoryHeadService
    {
        private IRepository<D.InventoryHead> _repository;
        private IMapper _mapper;

        public InventoryHeadService(InventoryHeadRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IReadOnlyCollection<B.InventoryHead>> GetAllItems(int inventoryDateId)
        {
            var items = await _repository.Find(t => t.InventoryDateId == inventoryDateId).ConfigureAwait(false);
            return items.Select(item => _mapper.Map<B.InventoryHead>(item)).ToArray();
        }
    }
}
