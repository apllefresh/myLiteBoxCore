using AutoMapper;
using Inventory.DAL.Contract.Interfaces;
using DA = Inventory.DAL.Contract.Models;
using BL = Inventory.BLL.Contract.Models;
using BLI = Inventory.BLL.Contract.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace Inventory.BLL.Services
{
    public class InventoryBodyService : BusinessLogicService<BL.InventoryBody, DA.InventoryBody>, BLI.IInventoryBodyService
    {
        protected IInventoryBodyRepository _repository;
        private IMapper _mapper;

        public string _productServiceUrl { get; }

        public InventoryBodyService(IInventoryBodyRepository repository, IMapper mapper, string productApiBaseUrl) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _productServiceUrl = productApiBaseUrl;
        }


        public async Task<IReadOnlyCollection<BL.InventoryBody>> GetAllItems(int inventoryBodyId)
        {
            var items = await _repository.Find(t => t.InventoryHeadId == inventoryBodyId).ConfigureAwait(false);
            var rr = items.Select(item => _mapper.Map<BL.InventoryBody>(item)).ToArray();
            foreach (var head in rr)
            {
                var req = WebRequest.Create(_productServiceUrl + @"/product/" + head.goodId);
                var resp = req.GetResponse();
                string sdata = string.Empty;
                using (var stream = new StreamReader( resp.GetResponseStream(), Encoding.UTF8))
                {
                    sdata = stream.ReadToEnd();
                }
                var data = JsonConvert.DeserializeObject<BL.Product>(sdata);
                head.Ean = data.Ean;
                head.Name = data.Name;
            }
            

            return rr.ToArray();
        }
    }
}
