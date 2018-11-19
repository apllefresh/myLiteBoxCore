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

        public InventoryHeadController(BI.IInventoryHeadService headService) : base(headService)
        {
            _headService = headService;
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetItemById(int id)
        {
            try
            {
                var services = await _headService.GetAllItems(id).ConfigureAwait(false);
                
                return Ok(JsonConvert.SerializeObject(services));
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [Route("getColumns")]
        public IActionResult GetColumns()
        {
            try
            {
                var columns = new
                {
                    Header = "number",
                    accessor = "number",
                    type = "text"
                };

                return  Ok(JsonConvert.SerializeObject(columns));
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

    }
}