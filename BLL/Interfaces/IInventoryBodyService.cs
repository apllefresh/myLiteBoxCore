using System.Collections.Generic;
using System.Threading.Tasks;
using B = BLL.Entities;
using D = InventoryDAL.Entities;
using ND = Inventory.DAL.Contract.Models;

namespace BLL.Interfaces
{
    public interface IInventoryBodyService : IBLLService<B.InventoryBody, ND.InventoryBody>
    {
        Task<IReadOnlyCollection<B.InventoryBody>> GetAllItems(int id);
    }
}
