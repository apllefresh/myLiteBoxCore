using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//using Inventory.DAL.Repositories;
using D = Inventory.DAL.Contract.Models;
using B = Inventory.BLL.Contract.Models;
using BI = Inventory.BLL.Contract.Interfaces;

namespace ReactClient.Controllers
{
    [Route("api/inventoryDate")]
    [ApiController]
    public class InventoryDateController : GenericController<B.InventoryDate, D.InventoryDate>
    {
        private BI.IInventoryDateService _dateService;

        public InventoryDateController(BI.IInventoryDateService dateService) : base(dateService)
        {
            _dateService = dateService;
        }

    }
}