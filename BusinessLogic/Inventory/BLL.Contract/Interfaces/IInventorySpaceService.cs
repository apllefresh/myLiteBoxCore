using BL = Inventory.BLL.Contract.Models;
using DA = Inventory.DAL.Contract.Models;

namespace Inventory.BLL.Contract.Interfaces
{
    public interface IInventorySpaceService : IBusinessLogicService<BL.InventorySpace, DA.InventorySpace>
    {
    }
}
