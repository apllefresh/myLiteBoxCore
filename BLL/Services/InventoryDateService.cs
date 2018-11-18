using B = BLL.Entities;
using BI = BLL.Interfaces;
using D = Inventory.DAL.Contract.Models;
using Inventory.DAL.Contract.Interfaces;
using AutoMapper;
using InventoryDAL.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BLL.Services
{
    public class InventoryDateService : BLLService<B.InventoryDate, D.InventoryDate>, BI.IInventoryDateService
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
