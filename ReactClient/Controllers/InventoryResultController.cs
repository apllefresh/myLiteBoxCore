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
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryResultController : GenericController<B.InventoryResult, D.InventoryResult>
    {
        private BI.IInventoryResultService _resultService;
        public InventoryResultController(BI.IInventoryResultService resultService) : base(resultService)
        {
            _resultService = resultService;
        }
    }
}