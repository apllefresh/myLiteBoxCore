using B = BLL.Entities;
using BI = BLL.Interfaces;
using D = DAL.Entities;
using DAL.Interfaces;
using AutoMapper;
using DAL.Repositories;
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


        public async Task<IReadOnlyCollection<B.InventoryHead>> GetAllItems(int InventoryDateId)
        {
            var items = await _repository.Find(t => t.InventoryDateId == InventoryDateId).ConfigureAwait(false);
            return items.Select(item => _mapper.Map<B.InventoryHead>(item)).ToArray();
        }
    }
}
