using BL = Inventory.BLL.Contract.Models;
using DA = Inventory.DAL.Contract.Models;

namespace Inventory.BLL.Contract.Interfaces
{
    public interface IInventoryDateToSpaceMapService : IBusinessLogicService<BL.InventoryDateToSpaceMap, DA.InventoryDateToSpaceMap>
    {
    }
}
