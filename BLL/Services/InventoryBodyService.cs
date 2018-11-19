﻿using B = BLL.Entities;
using BI = BLL.Interfaces;
using D = Inventory.DAL.Contract.Models;
using Inventory.DAL.Contract.Interfaces;
using InventoryDAL.Interfaces;
using AutoMapper;
using InventoryDAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BLL.Services
{
    public class InventoryBodyService : BLLService<B.InventoryBody, D.InventoryBody>, BI.IInventoryBodyService
    {
        private IInventoryBodyRepository _repository;
        private IMapper _mapper;

        public InventoryBodyService(IInventoryBodyRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IReadOnlyCollection<B.InventoryBody>> GetAllItems(int inventoryBodyId)
        {
            var items = await _repository.Find(t => t.InventoryHeadId == inventoryBodyId).ConfigureAwait(false);
            return items.Select(item => _mapper.Map<B.InventoryBody>(item)).ToArray();
        }
    }
}
