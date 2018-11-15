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
                var options = services.Select(head =>
                new
                {
                    label = head.Number,
                    value = head.Id
                });

                return Ok(JsonConvert.SerializeObject(options));
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetAllItems(int id)
        //{
        //    try
        //    {
        //        var services = await _headService.GetAllItems(id).ConfigureAwait(false);
        //        var options = services.Select(head =>
        //        new
        //        {
        //            label = head.Number,
        //            value = head.Id
        //        });

        //        return Ok(JsonConvert.SerializeObject(options));
        //    }
        //    catch (Exception exception)
        //    {
        //        return StatusCode(500, exception.Message);
        //    }
        //}
    }
}