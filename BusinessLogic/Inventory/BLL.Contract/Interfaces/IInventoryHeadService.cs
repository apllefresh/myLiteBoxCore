using System.Collections.Generic;
using System.Threading.Tasks;
using BL = Inventory.BLL.Contract.Models;
using DA = Inventory.DAL.Contract.Models;

namespace Inventory.BLL.Contract.Interfaces
{
    public interface IInventoryHeadService : IBusinessLogicService<BL.InventoryHead, DA.InventoryHead>
    {
        Task<IReadOnlyCollection<BL.InventoryHead>> GetAllItems(int id);
    }
}
