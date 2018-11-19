using System.Collections.Generic;
using System.Threading.Tasks;
using BL = Inventory.BLL.Contract.Models;
using DA = Inventory.DAL.Contract.Models;

namespace Inventory.BLL.Contract.Interfaces
{
    public interface IInventoryBodyService : IBusinessLogicService<BL.InventoryBody, DA.InventoryBody>
    {
        Task<IReadOnlyCollection<BL.InventoryBody>> GetAllItems(int id);
    }
}
