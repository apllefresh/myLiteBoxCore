using System.Collections.Generic;
using System.Threading.Tasks;
using B = BLL.Entities;
using ND = Inventory.DAL.Contract.Models;

namespace BLL.Interfaces
{
    public interface IInventoryHeadService : IBLLService<B.InventoryHead, ND.InventoryHead>
    {
        Task<IReadOnlyCollection<B.InventoryHead>> GetAllItems(int id);
    }
}
