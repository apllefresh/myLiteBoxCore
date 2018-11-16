using System.Collections.Generic;
using System.Threading.Tasks;
using B = BLL.Entities;
using D = InventoryDAL.Entities;

namespace BLL.Interfaces
{
    public interface IInventoryBodyService : IBLLService<B.InventoryBody, D.InventoryBody>
    {
        Task<IReadOnlyCollection<B.InventoryBody>> GetAllItems(int id);
    }
}
