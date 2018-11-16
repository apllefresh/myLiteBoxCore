using B = BLL.Entities;
using BI = BLL.Interfaces;
using D = InventoryDAL.Entities;
using InventoryDAL.Interfaces;
using AutoMapper;
using InventoryDAL.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BLL.Services
{
    public class InventoryDateService : BLLService<B.InventoryDate, D.InventoryDate>, BI.IInventoryDateService
    {
        private IRepository<D.InventoryDate> _repository;
        private IMapper _mapper;

        public InventoryDateService(InventoryDateRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
