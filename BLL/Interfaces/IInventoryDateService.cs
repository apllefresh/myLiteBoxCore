using B = BLL.Entities;
using D = InventoryDAL.Entities;
using ND = Inventory.DAL.Contract.Models;

namespace BLL.Interfaces
{
    public interface IInventoryDateService : IBLLService<B.InventoryDate, ND.InventoryDate>
    {

    }
}
