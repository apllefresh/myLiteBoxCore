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
    [Route("api/inventoryHead")]
    [ApiController]
    public class InventoryHeadController : GenericController<B.InventoryHead, D.InventoryHead>
    {
        private BI.IInventoryHeadService _headService;
        private BI.IInventorySpaceService _spaceService;

        public InventoryHeadController(BI.IInventoryHeadService headService, BI.IInventorySpaceService spaceService) : base(headService)
        {
            _headService = headService;
            _spaceService = spaceService;
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetItemById(int id)
        {
            try
            {
                var heads = await _headService.GetAllItems(id).ConfigureAwait(false);
                return Ok(JsonConvert.SerializeObject(heads));
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

    }
}