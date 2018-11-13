using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DAL.Repositories;
using D = DAL.Entities;
using B = BLL.Entities;
using BI = BLL.Interfaces;

namespace API.Controllers
{
    [Route("api/inventory")]
    [ApiController]
    public class InventoryDateController : GenericController<B.InventoryDate, D.InventoryDate>
    {
        private BI.IInventoryService _formulaService;

        public InventoryDateController(BI.IInventoryService formulaService) : base(formulaService)
        {
            _formulaService = formulaService;
        }

        [HttpGet]
        public override IActionResult GetAllItems()
        {
            try
            {
                var services = _formulaService.GetAllItems();
                var options = services.Select(date =>
                new
                {
                    label = date.date,
                    value = date.id
                });
                
                return Ok(JsonConvert.SerializeObject(options));
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
    }
}