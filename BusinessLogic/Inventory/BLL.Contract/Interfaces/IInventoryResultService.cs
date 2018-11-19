using BL = Inventory.BLL.Contract.Models;
using DA = Inventory.DAL.Contract.Models;

namespace Inventory.BLL.Contract.Interfaces
{
    public interface IInventoryResultService : IBusinessLogicService<BL.InventoryResult, DA.InventoryResult>
    {
    }
}
