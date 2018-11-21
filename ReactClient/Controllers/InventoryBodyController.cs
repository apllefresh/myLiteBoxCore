﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using D = Inventory.DAL.Contract.Models;
using B = Inventory.BLL.Contract.Models;
using BI = Inventory.BLL.Contract.Interfaces;

namespace ReactClient.Controllers
{
    [Route("api/inventoryBody")]
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