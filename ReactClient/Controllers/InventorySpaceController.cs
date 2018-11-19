using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using D = Inventory.DAL.Contract.Models;
using B = Inventory.BLL.Contract.Models;
using BI = Inventory.BLL.Contract.Interfaces;

namespace ReactClient.Controllers
{
    [Route("api/inventorySpace")]
    [ApiController]
    public class InventorySpaceController : GenericController<B.InventorySpace, D.InventorySpace>
    {
        private BI.IInventorySpaceService _spaceService;
        public InventorySpaceController(BI.IInventorySpaceService spaceService) : base(spaceService)
        {
            _spaceService = spaceService;
        }
    }
}
