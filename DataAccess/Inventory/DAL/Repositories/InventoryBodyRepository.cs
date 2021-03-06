﻿using AutoMapper;
using Inventory.DAL.Contract.Interfaces;
using Inventory.DAL.EF;
using Inventory.DAL.Contract.Models;

namespace Inventory.DAL.Repositories
{
    public class InventoryBodyRepository : DataAccessRepository<InventoryBody>,IInventoryBodyRepository
    {
        protected DataAccessContext _context;
        protected IMapper _mapper;

        public InventoryBodyRepository(DataAccessContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
