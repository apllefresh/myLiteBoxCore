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
        private BI.IInventoryService _businessLogicService;

        public InventoryDateController(BI.IInventoryService businessLogicService) : base(businessLogicService)
        {
            _businessLogicService = businessLogicService;
        }

        [HttpGet]
        public override IActionResult GetAllItems()
        {
            try
            {
                var services = _businessLogicService.GetAllItems();
                var q = from d in services
                        select new
                        {
                            label = d.date,
                            value = d.id
                        };
                return Ok(JsonConvert.SerializeObject(q));
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

    }
}