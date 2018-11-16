using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using D = InventoryDAL.Entities;
using B = BLL.Entities;
using BI = BLL.Interfaces;

namespace ReactClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryBodyController : GenericController<B.InventoryBody, D.InventoryBody>
    {
        private BI.IInventoryBodyService _bodyService;

        public InventoryBodyController(BI.IInventoryBodyService bodyService) : base(bodyService)
        {
            _bodyService = bodyService;
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetItemById(int id)
        {
            try
            {
                var services = await _bodyService.GetAllItems(id).ConfigureAwait(false);
                return Ok(JsonConvert.SerializeObject(services));
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
    }
}